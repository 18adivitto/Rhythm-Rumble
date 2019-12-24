using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeatDetection : MonoBehaviour
{
    BeatTracker BT;
    float buffer = .2f;

    public GameObject pass;
    public GameObject fail;

    public bool punching = false;

    // Start is called before the first frame update
    void Start()
    {
        BT = GameObject.Find("MusicManager").GetComponent<BeatTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if ((BT.songPosInBeats > (Mathf.Round(BT.songPosInBeats) - buffer)) && (BT.songPosInBeats < (Mathf.Round(BT.songPosInBeats) + buffer)))
            {
                //punching = true;
                //Debug.Log("PASS");
                Instantiate(pass, this.gameObject.transform);
            }
            else
            {
                //punching = false;
                //Debug.Log("FAIL");
                Instantiate(fail, this.gameObject.transform);
            }
           // Debug.Log(BT.songPosInBeats - Mathf.Round(BT.songPosInBeats));
        }
    }


}
