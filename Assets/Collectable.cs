using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public bool grounded;
    public Rigidbody2D myRb;
    public bool canCollect = false;

	// Use this for initialization
	void Start () {
        myRb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //grounded = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 0.25f), 1 << LayerMask.NameToLayer("Ground"));
        //if (grounded)
        //{
        //    myRb.AddForce(new Vector2(0, 50));
        //}

        grounded = Physics2D.Linecast(transform.position, new Vector2(transform.position.x, transform.position.y - 0.245f), 1 << LayerMask.NameToLayer("Ground"));
        if (grounded)
        {
            myRb.velocity = new Vector2(myRb.velocity.x, 0);
            myRb.gravityScale = 0;
            canCollect = true;
        }
        else
        {
            myRb.gravityScale = 1;
        }
    }
}
