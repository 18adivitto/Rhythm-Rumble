using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class InputTracker : MonoBehaviour
{

    PlayerMovement PM;
    PlayerBeatDetection PBD;
    BeatTracker BT;
    int PLAYERID;
    Player player;

    public static int beatNo = 0;

    public GameObject playerInput;

    public static string[] player0Actions;
    public static string[] player1Actions;

    int beatsInsong;

    // Start is called before the first frame update
    void Start()
    {
        BT = GameObject.Find("MusicManager").GetComponent<BeatTracker>();

        beatsInsong = Mathf.RoundToInt(BT.songBpm * (BT.songTimeInRealSec / 60));

        player0Actions = new string[beatsInsong];
        player1Actions = new string[beatsInsong];


        PBD = GetComponent<PlayerBeatDetection>();
        PM = GetComponent<PlayerMovement>();
        PLAYERID = PM.PLAYERID;
        player = ReInput.players.GetPlayer(PLAYERID);
    }

    // Update is called once per frame
    void Update()
    {
        if (BT.songPosInBeats > beatNo)
        {
            Instantiate(playerInput, new Vector3(56.37497f, 266.4025f, 0), Quaternion.identity, GameObject.Find("Canvas").transform);
            beatNo++;
        }

    }
}
