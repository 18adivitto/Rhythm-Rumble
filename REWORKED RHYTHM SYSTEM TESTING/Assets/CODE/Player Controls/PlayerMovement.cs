using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController characterController;

     float speed = 3.5f;
     float jumpSpeed = 11.0f;
     float gravity = 40.0f;

    public Vector3 moveDirection = Vector3.zero;

    CameraMovement CamData;
    PlayerAnimations AnimData;

    bool touchingController;
    bool onRight;
    bool slidingOff;
    float slideDirection;

    BoxCollider boxColl;

    public bool crouching = false;

    void Start()
    {
        CamData = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
        AnimData = GetComponent<PlayerAnimations>();
        characterController = GetComponent<CharacterController>();
        boxColl = GetComponent<BoxCollider>();
    }

    void Update()
    {
        RelativePositionCalc();
        ColliderPos();
        if (characterController.isGrounded)
        {

            // We are grounded, so recalculate
            // move direction directly from axes

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0);
            moveDirection *= speed;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection.y = jumpSpeed;
            }
            slidingOff = false;

            if (Input.GetKey(KeyCode.S))
            {
                crouching = true;
            }
            else
            {
                crouching = false;
            }
        }


        moveDirection.y -= gravity * Time.deltaTime;
        if (this.gameObject.name[0] == '0') //FOR DEBUGGING ONLY
        {
            if (crouching || AnimData.punching)
            {
                moveDirection.x = 0;
            }
        }
        else
        {
            moveDirection.x = 0;
            moveDirection.y = -1;
        }
        characterController.Move(moveDirection * Time.deltaTime);
    }
    void ColliderPos()
    {
        if (onRight)
        {
            boxColl.center = new Vector3(-7, 2, 0);
        }
        else
        {
            boxColl.center = new Vector3(7, 2, 0);
        }
    }
    void RelativePositionCalc()
    {
        if (AnimData.otherPlayer.position.x > transform.position.x)
        {
            onRight = false;
            slideDirection = -1;
        }
        else 
        {
            onRight = true;
            slideDirection = 1;
        }
    }
}
