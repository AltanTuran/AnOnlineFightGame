using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class hareket : MonoBehaviourPun , IPunObservable
{
    public Transform hitpoint;

    bool rolling = false;
    public LayerMask karakterlayer;
    private SpriteRenderer spriteRenderer;
    public Slider Canslider;
    public Slider Enerjislider;
    public float enerji = 100f;
    public float can = 100;
    public float Speed = 7f;
    Vector2 hp;
    Rigidbody2D rigid;
    Vector2 movement;
    Animator animator;
    public GameObject[] players;
    PhotonView pw;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        pw = GetComponent<PhotonView>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        enerji = Mathf.Min(enerji + 60 * Time.deltaTime, 100);
        if (pw.IsMine)
        {
            if (Input.GetMouseButtonDown(0) && enerji == 100)
            {
                Collider2D[] vurulandusmanlar = Physics2D.OverlapCircleAll(hitpoint.position, 0.7f, karakterlayer);
                for (int i = 0; i < vurulandusmanlar.Length; i++)
                {
                    vurulandusmanlar[i].GetComponent<hareket>().pw.RPC("HasarAl", RpcTarget.AllBuffered, 20);
                }
                pw.RPC("Attack", RpcTarget.AllBuffered);
                animator.SetTrigger("attack");

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && enerji >= 50)
            {
                pw.RPC("Roll", RpcTarget.AllBuffered);
            }
            if (!rolling)
            {
                Hareket();
            }
            pw.RPC("SliderUpdate", RpcTarget.AllBufferedViaServer);


            if (movement.x < 0)
            {
                //pw.RPC("FlipSprite", RpcTarget.AllBuffered, true);
                transform.localScale = new Vector3(-0.75f, 0.75f, 1);

            }
            if (movement.x > 0)
            {
                //pw.RPC("FlipSprite", RpcTarget.AllBuffered, false);
                transform.localScale = new Vector3(0.75f, 0.75f, 1);
            }

        }
    }




    private void FixedUpdate()
    {




    }



    [PunRPC]
    public void SliderUpdate()
    {
        Enerjislider.value = enerji;
        Canslider.value = can;
    }

    [PunRPC]
    public void Attack()
    {

        enerji = 0;
    }

    [PunRPC]
    public void HasarAl(int hasar)
    {

        can -= hasar;


    }
    public void Attackapa()
    {
        animator.SetBool("attack", false);
    }
    public void Hareket()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(movement.x * Speed, movement.y * Speed);
        if (rigid.velocity == Vector2.zero)
        {
            animator.SetBool("hareket", false);
        }
        else
        {
            animator.SetBool("hareket", true);
        }

    }
    [PunRPC]
    public void Roll()
    {
        if (rolling == false)
        {
            Speed = 10f;
            enerji -= 50;
            rolling = true;
            rigid.AddForce(transform.forward * 50, ForceMode2D.Impulse);
            animator.SetTrigger("roll");

        }


    }
    public void RollKapa()
    {
        rolling = false;
        Speed = 7f;
    }


    [PunRPC]
    private void FlipSprite(bool flip)
    {
        spriteRenderer.flipX = flip;
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // Veri gönderme
            stream.SendNext(spriteRenderer.flipX);
            stream.SendNext(can);
            stream.SendNext(enerji);

        }
        else
        {
            // Veri alma
            spriteRenderer.flipX = (bool)stream.ReceiveNext();
            can = (float)stream.ReceiveNext();
            enerji = (float)stream.ReceiveNext();


        }
    }
}