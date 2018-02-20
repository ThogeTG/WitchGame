using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWall : MonoBehaviour {

    public GameObject spriteObject;
    public List<Sprite> spriteS = new List<Sprite>();
    private float changeTime = 0;
    public int curFrame = 0;
    public float fps = 10;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject itemsNeeded; 

    public List<Sprite> unlockWith = new List<Sprite>();

    // Use this for initialization
    void Start () {
        spriteObject = transform.Find("Sprite").gameObject;
        
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;

        if (changeTime < 0)
        {
            if (curFrame < spriteS.Count - 1)
            {
                curFrame += 1;
            }
            else
            {
                curFrame = 0;
            }
            spriteObject.GetComponent<SpriteRenderer>().sprite = spriteS[curFrame];
            changeTime = 1 / fps;
        }
    }
}
