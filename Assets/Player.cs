using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 10f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool jump = false;
    [SerializeField]
    private bool grounded;
    [SerializeField]
    Transform groundCheck;

    private Vector3 moveDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        moveDir = new Vector2(h, 0);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

        if (jump == true)
        {
            //rb.AddForce(new Vector2(0f, jumpForce));
            rb.velocity = new Vector2(0, 6);
            jump = false;
        }
    }

    void Update()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
    }
}
