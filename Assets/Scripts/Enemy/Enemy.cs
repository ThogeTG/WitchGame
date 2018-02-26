using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D myRB;
    public Transform player;
    public float thrust;
    float verticalDistance;
    public float jumpTimer = 3;
    public int HP;
    public AudioSource aSource;
    public AudioClip jumpSound;
    public AudioClip landingSound;
    [SerializeField]
    bool grounded;
    [SerializeField]
    Transform groundCheck;
    public SpriteRenderer spriteRen;
    public GameObject attack;
    

    // Use this for initialization
    void Start ()
    {
        spriteRen = gameObject.GetComponent<SpriteRenderer>();

        spriteRen.flipX = false;

        player = GameObject.Find("Player").transform;

        verticalDistance = transform.position.x - player.transform.position.x;

        aSource = GetComponent<AudioSource>();

        myRB = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.transform.position, 1 << LayerMask.NameToLayer("Ground"));

        jumpTimer -= Time.deltaTime;

        if (transform.position.x < player.transform.position.x)
        {
            spriteRen.flipX = false;
        }

        else if (transform.position.x > player.transform.position.x)
        {
            spriteRen.flipX = true;
        }

        if (jumpTimer <= 0 && grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        

    }

    void Jump()
    {
        aSource.clip = jumpSound;
        aSource.Play();

        if (transform.position.x < player.transform.position.x)
        {
            myRB.AddForce(transform.up * thrust * 4);
            myRB.AddForce(transform.right * thrust);
        }

        else if (transform.position.x > player.transform.position.x)
        {
            myRB.AddForce(transform.up * thrust * 4);
            myRB.AddForce(-transform.right * thrust);
        }

        else if (verticalDistance == 0)
        {
            myRB.AddForce(transform.up * thrust * 4);
        }

        jumpTimer = 3;
    }

    private void OnTriggerEnter2D(Collider2D attack)
    {
        if (attack.tag == "fireball")
        {
            HP--;
            Destroy(attack.gameObject);

            if (HP == 0)
            {
                DestroyObject(gameObject);
            }
        }
        
    }


}
