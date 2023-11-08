using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nickhrkt : MonoBehaviour
{
    public float Speed = 7f;
    Rigidbody2D rigid;
    Vector2 movement;
    public Transform karakter;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(karakter.position.x, karakter.position.y + 1.3f);
    }
    public void Hareket()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        rigid.velocity = new Vector2(movement.x * Speed, movement.y * Speed);
       

    }
}
