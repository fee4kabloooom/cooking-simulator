using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroControl : MonoBehaviour
{
    [SerializeField] GameObject sprite;
    [SerializeField] float speed;
    Animator anim;
    Rigidbody2D rb;

    Vector2 move;
    bool isMoving;
    bool isForward;
    RaycastHit2D hit;
    GameObject selected;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        hit = Physics2D.Raycast(ray.origin, ray.direction);

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        RotateHero();
        SelectObject();
    }
    private void FixedUpdate()
    {
        if(move.x != 0 && move.y != 0) rb.MovePosition(rb.position + move * speed/1.5f * Time.deltaTime);
        else rb.MovePosition(rb.position + move * speed * Time.deltaTime);
    }
    void SelectObject()
    {
        if (hit.collider && hit.collider.GetComponent<Interactable>())
        {
            GameController.Instance().selected.SetActive(true);
            GameController.Instance().selected.transform.position = hit.collider.transform.position;
        }
        else GameController.Instance().selected.SetActive(false);
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

        if (move.x > 0) sprite.transform.localScale = new Vector3(1, sprite.transform.localScale.y, sprite.transform.localScale.z);
        if (move.x < 0) sprite.transform.localScale = new Vector3(-1, sprite.transform.localScale.y, sprite.transform.localScale.z);
    }
}
