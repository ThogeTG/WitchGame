using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour {

    public List<GameObject> items;

    public List<string> itemNames = new List<string>(); 
    // Use this for initialization
    void Start () {
        items.Add(gameObject.transform.Find("Item01").gameObject);
        items.Add(gameObject.transform.Find("Item02").gameObject);
        items.Add(gameObject.transform.Find("Item03").gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Add(GameObject collectable)
    {
        if (itemNames.Count <= 3)
        {
            items[itemNames.Count].GetComponent<Image>().sprite = collectable.transform.Find("Sprite").GetComponent<SpriteRenderer>().sprite;
            itemNames.Add(items[itemNames.Count].GetComponent<Image>().sprite.name);
        }
    }
}
