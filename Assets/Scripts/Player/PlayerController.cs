using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 1000f;

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

        moveDir = new Vector3(h, 0, 0);

        transform.position += moveDir * moveSpeed * Time.deltaTime;

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
