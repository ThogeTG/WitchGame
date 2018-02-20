using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool changeRoom;

    public GameObject player;

    public GameObject room2Collider;

    private int speed = 10;

    public GameObject roomChanger;

    public bool moveRight;
    public Vector3 targetPosition;

    public PlayerController playerController;

    void Start()
    {
        roomChanger = GameObject.FindGameObjectWithTag("RoomChanger");

        playerController = player.GetComponent<PlayerController>();
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
                moveRight = true;

                targetPosition = new Vector3(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z);

                //player.transform.position = Vector3.MoveTowards(player.transform.position, room2Collider.transform.position, step);
            }
        }

        if (moveRight == true)
        {
            float step = speed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);

            if (player.transform.position.x == targetPosition.x)
            {
                moveRight = false;

                playerController.canMove = true;
            }
        }
        
    }

    public void ChangeRoom()
    {
        changeRoom = true;
    }
}
