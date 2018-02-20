using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSprites : MonoBehaviour {

    public GameObject itemsNeeded;
    public GameObject player;
    public GameObject[] walls;
    public List<SpriteRenderer> neededSprites;

	// Use this for initialization
	void Start () {
        itemsNeeded = GameObject.Find("ItemsNeeded");
        player = GameObject.Find("Player");
        walls = GameObject.FindGameObjectsWithTag("SlimeWall");

        for (int i = 0; i < itemsNeeded.transform.childCount; ++i)
        {
            neededSprites.Add(itemsNeeded.transform.GetChild(i).GetComponent<SpriteRenderer>());
        }
           
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < walls.Length; i++)
        {
            if (5 > Vector2.Distance(player.transform.position, walls[i].transform.position))
            {
                itemsNeeded.transform.position = new Vector3(walls[i].transform.position.x - 3.5f, walls[i].transform.position.y + 2);
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
