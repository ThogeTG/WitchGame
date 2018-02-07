using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public int roomNumber;
    [SerializeField]
    private bool canMove;
    [SerializeField]
    private bool cannotMoveDown;
    [SerializeField]
    private bool rightWall;
    private float yOffset;

    private bool floor;

    void Start()
    {
        canMove = true;

        //transform.position.Set(player.transform.position.x, player.transform.position.y + 0.5f, transform.position.z);
    }

    void Update()
    {

    }

    void LateUpdate()
    {
        /*if (cannotMoveDown == true && canMove == true)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }*/


        /*if (canMove == true && cannotMoveDown == false)
        {

        }*/

        if (canMove == true)
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        }


        if (canMove == false && cannotMoveDown == true)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);

            if (rightWall == false && player.transform.position.x >= transform.position.x)
            {
                canMove = true;
            }

            if (rightWall == true && player.transform.position.x <= transform.position.x)
            {
                canMove = true;
            }
        }

        if (cannotMoveDown == true && player.transform.position.y >= transform.position.y)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }

        Debug.Log("player.transform.position.x=" + player.transform.position.x);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RoomColliderLeft")
        {
            canMove = false;
            rightWall = false;
            transform.position.Set(transform.position.x + 0.1f, transform.position.y, transform.position.z);
        }

        if (collision.tag == "RoomColliderRight")
        {
            canMove = false;
            rightWall = true;
            transform.position.Set(transform.position.x - 0.1f, transform.position.y, transform.position.z);
        }

        if (collision.tag == "RoomColliderFloor")
        {
            floor = true;
            cannotMoveDown = true;
            //canMove = false;
            transform.position.Set(transform.position.x, transform.position.y + 0.1f, transform.position.z);
        }
    }
}
