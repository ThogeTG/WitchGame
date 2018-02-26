using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {

    public bool grounded;
    public Rigidbody2D myRb;
    public bool canCollect = false;

    public ItemManager itemManager;

    // Use this for initialization
    void Start () {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        itemManager = GameObject.Find("ItemManager").GetComponent<ItemManager>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && canCollect == true)
        {
            itemManager.Add(gameObject);
        }
    }
}
