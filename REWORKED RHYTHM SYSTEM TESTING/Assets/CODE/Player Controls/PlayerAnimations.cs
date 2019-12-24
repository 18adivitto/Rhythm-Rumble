using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    //ANIMATION VARIABLES
    public Sprite[] Idle;
    int idleFrames = 0;

    public Sprite[] Walk;
    int walkFrames = 0;

    public Sprite Crouch;

    public Sprite Jump;

    public Sprite Punch;
    int punchFrames = 0;

    public Sprite CrouchPunch;

    bool walking = false;
    public bool punching = false;
    //ANIMATION VARIABLES

    PlayerMovement Controls;
    PlayerBeatDetection beatDetect;
    CharacterController cc;

    SpriteRenderer SR;

    BeatTracker stageMusic;

    float beatNo;
    float punchBeatNo;

    bool everyOther;

    int playerNum;

    public Transform otherPlayer;

    // Start is called before the first frame update
    void Start()
    {
        beatDetect = GetComponent<PlayerBeatDetection>();
        Controls = GetComponent<PlayerMovement>();
        cc = GetComponent<CharacterController>();
        SR = GetComponentInChildren<SpriteRenderer>();
        stageMusic = GameObject.Find("MusicManager").GetComponent<BeatTracker>();
        beatNo = 1;
        SR.sprite = Idle[0];

        idleFrames = 1;

        playerNum = int.Parse(this.gameObject.name[0].ToString());

        ColorPicker(playerNum);
    }

    void ColorPicker(int playerNUM)
    {
        if (playerNUM == 0)
        {
            SR.color = Color.red;
            otherPlayer = GameObject.Find("1Player").transform;
        }
        else
        {
            SR.color = Color.cyan;
            otherPlayer = GameObject.Find("0Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (punching)
        {
            PunchDelay();
        }

        if (otherPlayer.transform.position.x > transform.position.x)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true;
        }

        //if walking
        if (Mathf.Abs(Controls.moveDirection.x) > 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }
        

        if (stageMusic.songPosInBeats >= beatNo)
        {
            if (!walking && !Controls.crouching && cc.isGrounded)
            {
                idleFrames++;
                if (idleFrames == Idle.Length)
                {
                    idleFrames = 0;
                }
            }
            else if (walking && !Controls.crouching && cc.isGrounded)
            {
                walkFrames++;
                if (walkFrames == Walk.Length)
                {
                    walkFrames = 0;
                }
            }
            beatNo +=.5f;
        }

        if (!walking && !Controls.crouching && cc.isGrounded)
        {
            SR.sprite = Idle[idleFrames];
        }
        else if (walking && !Controls.crouching && cc.isGrounded)
        {
            SR.sprite = Walk[walkFrames];
        }
        else if (Controls.crouching && cc.isGrounded)
        {
            SR.sprite = Crouch;
        }
        else if (!cc.isGrounded)
        {
            SR.sprite = Jump;
        }

        if (punching && cc.isGrounded && !Controls.crouching)
        {
            SR.sprite = Punch;
        }
        else if (punching && cc.isGrounded && Controls.crouching)
        {
            SR.sprite = CrouchPunch;
        }

        if (Input.GetKeyDown(KeyCode.Return) && !punching)
        {
            punchBeatNo = stageMusic.songPosInBeats + .25f;
            punching = true;
        }
    }

    void PunchDelay()
    {
        if (stageMusic.songPosInBeats >= punchBeatNo)
        {
            punching = false;
        }
    }
}
