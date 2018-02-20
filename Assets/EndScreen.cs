using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour {

    public List<Sprite> images;
    [SerializeField]
    private float changeTime;
    private Image ima;
    public int curFrame = 0;
    public float fps = 10;
    public GameObject scoreText;
    public int score;

	// Use this for initialization
	void Start () {
        changeTime = 1/fps;
	}

    // Update is called once per frame
    void Update() {

        changeTime -= Time.deltaTime;

        if (changeTime < 0)
        {
            if (curFrame < images.Count - 1)
            {
                curFrame += 1;
            }
            else
            {
                curFrame = 0;
            }
            gameObject.GetComponent<Image>().overrideSprite = images[curFrame];
            changeTime = 1 / fps;
        }

        scoreText.GetComponent<Text>().text = "Score: " + score;
        }

	}

