using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

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

    public int PLAYERID;
    Player player;

    void Start()
    {
        PLAYERID = int.Parse(this.gameObject.name[0].ToString());
        player = ReInput.players.GetPlayer(PLAYERID);

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

            moveDirection = new Vector3(player.GetAxis("Horizontal"), 0.0f, 0);
            moveDirection *= speed;

            if (player.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            slidingOff = false;

            if (player.GetButton("Crouch"))
            {
                crouching = true;
            }
            else
            {
                crouching = false;
            }
        }


        moveDirection.y -= gravity * Time.deltaTime;

            if (crouching || AnimData.punching)
            {
                moveDirection.x = 0;
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
