using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool changeRoom;

    public GameObject player;

    public GameObject room2Collider;

    private int speed = 10;

    private GameObject roomChanger;

    void Start()
    {
        roomChanger = GameObject.FindGameObjectWithTag("RoomChanger");
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (changeRoom == true)
        {
            if (player.transform.position.x < roomChanger.transform.position.x)
            {
                float step = speed * Time.deltaTime;
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(player.transform.position.x + 5, player.transform.position.y, 0), step);

                //player.transform.position = Vector3.MoveTowards(player.transform.position, room2Collider.transform.position, step);
            }
        }
    }

    public void ChangeRoom()
    {
        changeRoom = true;
    }
}
