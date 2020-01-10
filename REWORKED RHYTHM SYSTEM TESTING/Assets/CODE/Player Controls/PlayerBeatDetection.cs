using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerBeatDetection : MonoBehaviour
{
    BeatTracker BT;
    public float buffer = .2f;

    public GameObject pass;
    public GameObject fail;

    public bool punching = false;

    int PLAYERID;
    Player player;

    public bool passed;
    public bool InputTrackingOn = true;
    int beatNo = 0;
    bool holdCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        PLAYERID = int.Parse(this.gameObject.name[0].ToString());
        player = ReInput.players.GetPlayer(PLAYERID);
        BT = GameObject.Find("MusicManager").GetComponent<BeatTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BT.songPosInBeats >= beatNo)
        {
            holdCheck = true;
            beatNo++;
        }
        PlayerInputDetection();
    }

    void PlayerInputDetection()
    {

        passed = (BT.songPosInBeats > (Mathf.Round(BT.songPosInBeats) - buffer)) && (BT.songPosInBeats < (Mathf.Round(BT.songPosInBeats) + buffer));



        //PUNCHES
        if (player.GetButtonDown("Light_Punch"))
        {
            if (passed)
            {
                ActionLogger(InputTracker.beatNo, "LP");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                Instantiate(fail, this.gameObject.transform);
            }
        }
        if (player.GetButtonDown("Hard_Punch"))
        {
            if (passed)
            {
                ActionLogger(InputTracker.beatNo, "HP");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                Instantiate(fail, this.gameObject.transform);
            }
        }
        //PUNCHES

        //KICKS
        if (player.GetButtonDown("Light_Kick"))
        {
            if (passed)
            {
                ActionLogger(InputTracker.beatNo, "LK");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                Instantiate(fail, this.gameObject.transform);
            }
        }
        if (player.GetButtonDown("Hard_Kick"))
        {
            if (passed)
            {
                ActionLogger(InputTracker.beatNo, "HK");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                Instantiate(fail, this.gameObject.transform);
            }
        }
        //KICKS

        //BLOCK AND GRAB
        if (player.GetButtonDown("Grab"))
        {
            if (passed)
            {
                ActionLogger(InputTracker.beatNo, "GRAB");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                Instantiate(fail, this.gameObject.transform);
            }
        }
        if (player.GetButtonDown("Block"))
        {
            if (passed)
            {
                ActionLogger(InputTracker.beatNo, "BLOCK");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                Instantiate(fail, this.gameObject.transform);
            }
        }
        //BLOCK AND GRAB

        //SIMULTANEOUS INPUTS
        if (player.GetButton("R1"))
        {
            if (player.GetButtonDown("Hard_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "HP+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Light_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "LP+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Hard_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "HK+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Light_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "LK+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }

        }
        if (player.GetButton("L1"))
        {
            if (player.GetButtonDown("Hard_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "HP+L1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Light_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "LP+L1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Hard_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "HK+L1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Light_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "LK+L1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }

        }
        if (player.GetButton("L1") && player.GetButton("R1"))
        {
            if (player.GetButtonDown("Hard_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "HP+L1+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Light_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "LP+L1+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Hard_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "HK+L1+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonDown("Light_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "LK+L1+R1");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }

        }
        //SIMULTANEOUS INPUTS

        //HOLD AND RELEASE
        if (holdCheck)
        {
            if (player.GetButton("Light_Punch"))
            {
                ActionLogger(InputTracker.beatNo, "_LP");
                Instantiate(pass, this.gameObject.transform);
            }
            else if (player.GetButton("Hard_Punch"))
            {
                ActionLogger(InputTracker.beatNo, "_HP");
                Instantiate(pass, this.gameObject.transform);
            }
            else if (player.GetButton("Light_Kick"))
            {
                ActionLogger(InputTracker.beatNo, "_LK");
                Instantiate(pass, this.gameObject.transform);
            }
            else if (player.GetButton("Hard_Kick"))
            {
                ActionLogger(InputTracker.beatNo, "_HK");
                Instantiate(pass, this.gameObject.transform);
            }
        }
        if (InputTracker.player0Actions[InputTracker.beatNo - 1] == "_LP" || 
            InputTracker.player0Actions[InputTracker.beatNo - 1] == "_HP" ||
            InputTracker.player0Actions[InputTracker.beatNo - 1] == "_LK" ||
            InputTracker.player0Actions[InputTracker.beatNo - 1] == "_HK") //ONLY WORKDS FOR PLAYER 0
        {
            if (player.GetButtonUp("Light_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "^LP^");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonUp("Hard_Punch"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "^HP^");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonUp("Light_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "^LK^");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
            if (player.GetButtonUp("Hard_Kick"))
            {
                if (passed)
                {
                    ActionLogger(InputTracker.beatNo, "^HK^");
                    Instantiate(pass, this.gameObject.transform);
                }
                else
                {
                    Instantiate(fail, this.gameObject.transform);
                }
            }
        }
        //HOLD AND RELEASE

        holdCheck = false;
    }

    void ActionLogger(int beatNo, string ActionType) //beatNo is InputTracker.beatNo to be specific
    {
        if (PLAYERID == 0)
        {
            InputTracker.player0Actions[beatNo] = ActionType;
        }
        else if (PLAYERID == 1)
        {
            InputTracker.player1Actions[beatNo] = ActionType;
        }
    }

}
