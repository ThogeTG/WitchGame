using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpa : MonoBehaviour {

    public GameObject pressButt;
    public GameObject toShow;
    public Transform player;
    public SpriteRenderer toShowRend;
    public GameObject collectablePre;

    public Sprite colSprite;

    // Use this for initialization
    private void Awake()
    {
        toShow = Instantiate(pressButt, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), Quaternion.identity);
        toShowRend = toShow.GetComponent<SpriteRenderer>();
        toShowRend.enabled = false;
    }

    void Start ()
    {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (Vector3.Distance(transform.position, player.position) <= 2)
        {
            toShowRend.enabled = true;
            if(Input.GetButtonDown("Fire1"))
            {
                GameObject spawned;
                spawned = Instantiate(collectablePre, new Vector2(transform.position.x, transform.position.y +1), Quaternion.identity);
                spawned.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = colSprite;
                spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(4.0f, 6.0f)); 
            }
        }
        else
        {
            toShowRend.enabled = false;
        }
	}
}
