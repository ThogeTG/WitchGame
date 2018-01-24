using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D myRB;
    public Transform player;
    public float thrust;
    float verticalDistance;
    public float jumpTimer;
    public int HP;
    public AudioSource jumpSound;
    public AudioSource landingSound;
    bool grounded;
    [SerializeField]
    Transform ground;
    

    // Use this for initialization
    void Start ()
    {
        verticalDistance = transform.position.x - player.transform.position.x;

        jumpSound = GetComponent<AudioSource>();

        myRB = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        jumpTimer -= Time.deltaTime;

        grounded = Physics2D.Linecast(transform.position, 1 << LayerMask.NameToLayer("Ground"));

        if (jumpTimer <= 0)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        

    }

    void Jump()
    {
        jumpSound.Play();

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

    private void OnTriggerEnter2D(Collider2D fireball)
    {
        if (fireball.tag == "fireball")
        {
            HP--;
            DestroyObject(fireball);
        }
        
    }


}
