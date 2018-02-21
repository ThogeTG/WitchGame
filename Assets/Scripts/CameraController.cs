using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float floorY;
    public float wallX;
    public float xOffset = 0;
    public float yOffset = 0;
    public float cameraSize;

    public bool lastWasRight;

    public bool canMove;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        cameraSize = gameObject.GetComponent<Camera>().orthographicSize;

        canMove = true;
        //wallX;
    }


    void Update()
    {

    }

    private void FixedUpdate()
    {

    }

    //Only place where we set position of the camera.
    void LateUpdate()
    {
        if (canMove == true)
        {
            // Let's set Offset in Y axis.
            if (player.position.y > floorY)
            {
                yOffset = player.position.y;
            }
            else
            {
                yOffset = floorY;
            }

            // Let's set Offset in X axis.
            if (player.position.x > wallX && lastWasRight == false)
            {
                xOffset = player.position.x;
            }
            else if (player.position.x < wallX && lastWasRight == true)
            {
                xOffset = player.position.x;
            }
            else
            {
                xOffset = wallX;
            }

            transform.position = new Vector3(xOffset, yOffset, transform.position.z);
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canMove == true)
        {
            if (collision.tag == "RoomColliderLeft")
            {
                wallX = transform.position.x;
                lastWasRight = false;
            }
            if (collision.tag == "RoomColliderRight")
            {
                wallX = transform.position.x;
                lastWasRight = true;
            }
        }

        if (collision.tag == "RoomColliderFloor")
        {
            floorY = transform.position.y;
        }
        
    }
}
