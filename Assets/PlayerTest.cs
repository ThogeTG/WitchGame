using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private int playerHP;

    public int Health
    {
        get
        {
            return playerHP;
        }

        set
        {
            playerHP = value;
            Debug.Log("HP: " + playerHP);
            if (playerHP <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private Rigidbody2D rb;

    float h;
    float v;

    private bool jump = false;
    [SerializeField]
    private bool grounded;
    [SerializeField]
    Transform groundCheck;

    private Vector3 moveDir;

    public GameObject fireBall;
    [SerializeField]
    int fireBallSpeed;

    SpriteRenderer sr;

    public bool lookRight;

    //public LevelManager lvlManager;
    //public CameraController cameraController;

    public bool canMove;
    public bool canJump;

    public GameObject ladder;

    public float playerPositionY;

    void Start()
    {
        canMove = true;
        canJump = true;

        rb = GetComponent<Rigidbody2D>();
        sr = transform.Find("Sprite").GetComponent<SpriteRenderer>();

        lookRight = true;

        //lvlManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        //cameraController = Camera.main.GetComponent<CameraController>();

        //anim = GetComponent<Animator>();
        //playerFind = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        if (canMove == true)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            moveDir = new Vector2(h, 0);

            transform.position += moveDir * moveSpeed * Time.deltaTime;

            if (canJump == true)
            {
                if (Input.GetButtonDown("Jump") && grounded)
                {
                    jump = true;
                }

                if (jump == true)
                {
                    //rb.AddForce(new Vector2(0f, jumpForce));
                    rb.velocity = new Vector2(0, jumpSpeed);
                    jump = false;
                }
            }

            if (canJump == false)
            {
                moveDir = new Vector2(0, v);

                transform.position += moveDir * moveSpeed * Time.deltaTime;

                rb.gravityScale = 0;
                rb.drag = 100;
            }


        }
    }

    void Update()
    {
        if (h > 0.1f)
        {
            sr.flipX = false;
            lookRight = true;
        }
        if (h < -0.1f)
        {
            sr.flipX = true;
            lookRight = false;
        }

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));

        if (Input.GetButtonDown("Fire1"))
        {

            if (lookRight == true)
            {
                GameObject spawned = Instantiate(fireBall, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.1f, transform.position.z), transform.rotation);
                spawned.GetComponent<Rigidbody2D>().AddForce(new Vector2(fireBallSpeed, 0));

                Destroy(spawned, 2);
            }
            if (lookRight == false)
            {
                GameObject spawned = Instantiate(fireBall, new Vector3(transform.position.x - 0.5f, transform.position.y - 0.1f, transform.position.z), transform.rotation);
                spawned.GetComponent<Rigidbody2D>().AddForce(new Vector2(-fireBallSpeed, 0));

                Destroy(spawned, 2);
            }
        }
    }

    public void PlayerTakesDamage(int damage)
    {
        Health -= damage;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            PlayerTakesDamage(10);
        }

        if (collision.gameObject.tag == "RoomChanger")
        {
            GameObject roomChanger = collision.gameObject;
            //lvlManager.ChangeRoom(roomChanger);
            canMove = false;


            //cameraController.canMove = false;
            //cameraController.ChangeRoom();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climb")
        {
            canJump = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Climb")
        {
            canJump = true;

            rb.gravityScale = 1;
            rb.drag = 0;

            /*playerPositionY = transform.position.y + 2f;
            if (playerPositionY > ladder.transform.position.y)
            {
                rb.gravityScale = 1;
            }*/
        }
    }
}