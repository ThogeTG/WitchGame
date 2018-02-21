using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour {

    public List<Sprite> incredients;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, 5);
    }
    void OnTriggerEnter(Collider2D collider)
    {
        if(collider.tag == "SlimeWall")
        {
            Destroy(gameObject);
        }
    }
}
