using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSprites : MonoBehaviour {

    public GameObject itemsNeeded;
    public GameObject player;
    public List<GameObject> walls;
    public List<SpriteRenderer> neededSprites;

	// Use this for initialization
	void Start () {
        itemsNeeded = GameObject.Find("ItemsNeeded");
        player = GameObject.Find("Player");
        walls.AddRange(GameObject.FindGameObjectsWithTag("SlimeWall"));

        for (int i = 0; i < itemsNeeded.transform.childCount; ++i)
        {
            neededSprites.Add(itemsNeeded.transform.GetChild(i).GetComponent<SpriteRenderer>());
        }
           
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < walls.Count; i++)
        {
            if (5 > Vector2.Distance(player.transform.position, walls[i].transform.position))
            {
                if (player.transform.position.x < walls[i].transform.position.x)
                {
                    itemsNeeded.transform.position = new Vector3(walls[i].transform.position.x - 3.5f, walls[i].transform.position.y + 2);
                    itemsNeeded.transform.GetComponent<SpriteRenderer>().flipX = false;
                }
                else
                {
                    itemsNeeded.transform.position = new Vector3(walls[i].transform.position.x + 3.5f, walls[i].transform.position.y + 2);
                    itemsNeeded.transform.GetComponent<SpriteRenderer>().flipX = true;
                }

                for (int i2 = 0; i2 < 3; i2++)
                {
                    neededSprites[i2].sprite = walls[i].GetComponent<SlimeWall>().unlockWith[i2];
                }
            }
            else
            {
                itemsNeeded.transform.localPosition = Vector3.zero;
            }
        }
        
    }
}
