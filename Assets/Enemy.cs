using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Rigidbody2D myRB;
    public Transform player;
    public float thrust;

	// Use this for initialization
	void Start ()
    {

        myRB = gameObject.GetComponent<Rigidbody2D>();

       myRB.AddForce(transform.up * thrust);

        myRB.AddForceAtPosition(player.transform.position, player.transform.position * thrust);
        

    }
	
	// Update is called once per frame
	void Update ()
    {


		
	}

    private void FixedUpdate()
    {
        if (transform.position 
        {

        }


    }
}
