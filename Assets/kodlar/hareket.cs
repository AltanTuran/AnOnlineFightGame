using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class hareket : MonoBehaviour
{
    public enerjican enerjican;
    
    public Transform hitpoint;
    bool rolling = false;
    public LayerMask karakterlayer;
    private SpriteRenderer spriteRenderer;
    
   
    public float Speed = 7f;
    Vector2 hp;
    Rigidbody2D rigid;
    Vector2 movement;
    Animator animator;
    
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
        
        if (pw.IsMine)
        {
            if (Input.GetMouseButtonDown(0) && enerjican.enerji == 100)
            {
                Collider2D[] vurulandusmanlar = Physics2D.OverlapCircleAll(hitpoint.position, 0.7f, karakterlayer);
                for (int i = 0; i < vurulandusmanlar.Length; i++)
                {
                    vurulandusmanlar[i].GetComponent<hareket>().pw.RPC("HasarAl", RpcTarget.AllBuffered, 20);
                }
                pw.RPC("Attack", RpcTarget.AllBuffered);
                animator.SetTrigger("attack");

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && enerjican.enerji >= 50)
            {
                pw.RPC("Roll", RpcTarget.AllBuffered);
            }
            if (!rolling)
            {
                Hareket();
            }
            pw.RPC("SliderUpdate", RpcTarget.AllBuffered);


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


    

    [PunRPC]
    public void Attack()
    {

        enerjican.enerji = 0;
    }

    [PunRPC]
    public void HasarAl(int hasar)
    {

        enerjican.can -= hasar;


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
            enerjican.enerji -= 50;
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


}