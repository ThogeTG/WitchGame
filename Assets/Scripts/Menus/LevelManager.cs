using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool changeRoom;

    public GameObject player;
    public GameObject camera;

    public GameObject room2Collider;

    private int speed = 100;

    public GameObject roomChanger;

    public bool moveRight;
    public Vector3 targetPosition;

    public PlayerController playerController;
    public CameraController cameraController;

    void Start()
    {
        roomChanger = GameObject.FindGameObjectWithTag("RoomChanger");

        playerController = player.GetComponent<PlayerController>();

        cameraController = Camera.main.GetComponent<CameraController>();
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (changeRoom == true)
        {
            //Levelmanager moves player right
            if (moveRight == true)
            {
                float step = speed * Time.deltaTime;
                player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);
                //camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);

                if (player.transform.position.x == targetPosition.x)
                {
                    changeRoom = false;

                    playerController.canMove = true;

                    cameraController.canMove = true;
                    cameraController.lastWasRight = false;
                    cameraController.wallX = roomChanger.transform.position.x + (roomChanger.transform.position.x - cameraController.wallX);
                }
            }

            //Levelmanager moves player left
            if (moveRight == false)
            {
                float step = speed * Time.deltaTime;
                player.transform.position = Vector3.MoveTowards(player.transform.position, targetPosition, step);
                //camera.transform.position = new Vector3(player.transform.position.x, camera.transform.position.y, camera.transform.position.z);

                if (player.transform.position.x == targetPosition.x)
                {
                    changeRoom = false;

                    playerController.canMove = true;

                    cameraController.canMove = true;
                    cameraController.lastWasRight = true;
                    cameraController.wallX = roomChanger.transform.position.x + (roomChanger.transform.position.x - cameraController.wallX);
                }
            }
        }
    }

    public void ChangeRoom(GameObject fuckingChange)
    {
        roomChanger = fuckingChange;
        changeRoom = true;

        if (player.transform.position.x < roomChanger.transform.position.x)
        {
            moveRight = true;

            targetPosition = new Vector3(player.transform.position.x + 5, player.transform.position.y, player.transform.position.z);
        }

        else if (player.transform.position.x > roomChanger.transform.position.x)
        {
            moveRight = false;

            targetPosition = new Vector3(player.transform.position.x - 5, player.transform.position.y, player.transform.position.z);
        }
    }
}
