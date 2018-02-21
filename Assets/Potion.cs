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
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "SlimeWall")
        {
            int clear = 0;
            int ingCount = collision.gameObject.GetComponent<SlimeWall>().unlockWith.Count;
            List<Sprite> tempCheck = collision.gameObject.GetComponent<SlimeWall>().unlockWith;

            for (int i = 0; i < incredients.Count; i++)
            {
                for (int i2 = 0; i2 < tempCheck.Count; i2++)
                {
                    if (incredients[i] == tempCheck[i2])
                    {
                        clear += 1;
                        tempCheck.Remove(tempCheck[i2]);
                    }
                }
            }

            if (clear == ingCount)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
