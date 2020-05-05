using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;

    Vector2 move;
    bool isMoving;
    bool isForward;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");
        RotateHero();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
    void RotateHero()
    {
        if (move.x != 0 || move.y != 0) isMoving = true;
        else isMoving = false;
        if (isMoving) anim.SetInteger("state", 1);
        else anim.SetInteger("state", 0);

        if (move.y > 0) isForward = false;
        if (move.y < 0) isForward = true;
        if (isForward) anim.SetBool("isForward", true);
        else anim.SetBool("isForward", false);

        if (move.x > 0) transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        if (move.x < 0) transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
    }
}
