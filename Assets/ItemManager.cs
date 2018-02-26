using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{

    public List<GameObject> items;

    public List<Vector3> itemsOriPos;

    bool mixUpdate = false;
    bool eraseItemUpdate = false;
    public GameObject itemSelector;
    public int curItem;
    public GameObject collectablePre;
    public Transform player;

    public float mixAcceleration;
    public float mixSpeed;

    public float mixTimer = 1;

    public GameObject potionPre;

    public List<Sprite> itemSprites = new List<Sprite>();

    public Color emptyColor = new Color(0, 0, 0, 0);
    public Color fullColor = new Color(255, 255, 255, 255);
    [SerializeField]
    bool hasPotion;

    private GameObject spawned;

    // Use this for initialization
    void Start()
    {
        itemSelector = GameObject.Find("ItemSelector");
        itemSelector.active = false;
        items.Add(gameObject.transform.Find("Item01").gameObject);
        items.Add(gameObject.transform.Find("Item02").gameObject);
        items.Add(gameObject.transform.Find("Item03").gameObject);

        for (int i = 0; i < items.Count; i++)
        {
            itemsOriPos.Add(items[i].GetComponent<RectTransform>().position);
        }

        player = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m"))
        {
            mixUpdate = true;
        }

        if (Input.GetKeyDown("p") && hasPotion)
        {
            spawned = Instantiate(potionPre, player.transform.position, Quaternion.identity);
            spawned.GetComponent<Potion>().incredients = itemSprites;
            itemSprites = new List<Sprite>();
            if(player.GetComponent<SpriteRenderer>().flipX == true)
            {
                spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 5f);
            }
            else
            {
                spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 5f);
            }

            hasPotion = false;
            items[1].GetComponent<Image>().sprite = null;
            items[0].GetComponent<Image>().color = fullColor;
            items[2].GetComponent<Image>().color = fullColor;
            items[0].GetComponent<RectTransform>().position = itemsOriPos[0];
            items[2].GetComponent<RectTransform>().position = itemsOriPos[2];
            items[0].GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,0);
            items[2].GetComponent<RectTransform>().eulerAngles = new Vector3(0,0,0);
        }

        if (Input.GetKeyDown("x") && eraseItemUpdate == false && itemSprites.Count > 0)
        {
            EraseItem();
        }

        else if (Input.GetKeyDown("x") && itemSelector.active == true)
        {
            GameObject spawned2 = Instantiate(collectablePre, player.position, Quaternion.identity);
            spawned2.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite = itemSprites[curItem];
            spawned2.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-3.0f, 3.0f), Random.Range(4.0f, 6.0f));
            itemSprites.Remove(itemSprites[curItem]);

            for (int i = 0; i < items.Count; i++)
            {
                if (i < itemSprites.Count)
                {
                    items[i].GetComponent<Image>().sprite = itemSprites[i];
                } 
                else
                {
                    items[i].GetComponent<Image>().sprite = null;
                } 
            }
        }

        if (mixUpdate)
        {
            eraseItemUpdate = false;
            itemSelector.SetActive(false);

            mixTimer -= Time.deltaTime; 
            if (mixTimer < 0)
            {
                //Going outwards
                mixSpeed -= (Time.deltaTime * mixAcceleration);
            }
            else
            {
                mixSpeed += (Time.deltaTime * mixAcceleration);
            }

            items[0].GetComponent<RectTransform>().position -= new Vector3(mixSpeed,0,0);
            items[0].GetComponent<RectTransform>().Rotate(0, 0, mixSpeed * 2);
            items[2].GetComponent<RectTransform>().position += new Vector3(mixSpeed, 0, 0);
            items[2].GetComponent<RectTransform>().Rotate(0, 0, -mixSpeed * 2);

            if(items[0].GetComponent<RectTransform>().position.x >= items[1].GetComponent<RectTransform>().position.x)
            {
                //POTION IS BORN
                mixUpdate = false;
                items[1].GetComponent<Image>().sprite = potionPre.GetComponent<SpriteRenderer>().sprite;

                items[0].GetComponent<Image>().sprite = null;
                items[2].GetComponent<Image>().sprite = null;

                items[0].GetComponent<Image>().color = emptyColor;
                items[2].GetComponent<Image>().color = emptyColor;

                hasPotion = true;
            }

            //if (items[0].GetComponent<RectTransform>().x) 

                //items[2].GetComponent<RectTransform>().position += 0.1f;
        }
        if(eraseItemUpdate)
        {
            //Move to Right
            if (Input.GetKeyDown("c") && curItem < itemSprites.Count - 1)
            {
                curItem += 1;
                itemSelector.GetComponent<RectTransform>().position = items[curItem].GetComponent<RectTransform>().position;
            }
             //Move to Left
            if (Input.GetKeyDown("z") && curItem > 0)
            {
                curItem -= 1;
                itemSelector.GetComponent<RectTransform>().position = items[curItem].GetComponent<RectTransform>().position;
            }
            itemSelector.GetComponent<RectTransform>().Rotate(0, 0, 50 * Time.deltaTime);
        }
    }
    public void Add(GameObject collectable)
    {
        if (itemSprites.Count <= items.Count - 1)
        {
            items[itemSprites.Count].GetComponent<Image>().sprite = collectable.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite;
            itemSprites.Add(items[itemSprites.Count].GetComponent<Image>().sprite);
            Destroy(collectable);
        }
    }

    void EraseItem()
    {
        itemSelector.active = true;
        itemSelector.GetComponent<RectTransform>().position = items[curItem].GetComponent<RectTransform>().position;
        eraseItemUpdate = true;
    }
}
