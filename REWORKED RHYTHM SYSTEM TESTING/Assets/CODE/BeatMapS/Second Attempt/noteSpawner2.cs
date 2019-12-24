using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteSpawner2 : MonoBehaviour
{

    public GameObject[] note;
    BeatTracker BT;
    float beatNo;

    float[] beatpattern;
    int patternNo;

    // Start is called before the first frame update
    void Start()
    {
        beatpattern = new float[4];

        beatpattern[0] = .75f;
        beatpattern[1] = .25f;
        beatpattern[2] = .5f;
        beatpattern[3] = .5f;

        BT = GameObject.Find("MusicManager").GetComponent<BeatTracker>();
        beatNo = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(this.gameObject.name[0].ToString()) == 0)
        {
            if (BT.songPosInBeats > beatNo)
            {
                Instantiate(note[0], GameObject.Find("Canvas").transform);
                beatNo++;
            }
        }
        else
        {
            if (BT.songPosInBeats > beatNo)
            {
                Instantiate(note[1], GameObject.Find("Canvas").transform);
                beatNo++;
            }
        }
        //if (BT.songPosInBeats > beatNo)
        //{
        //    Instantiate(note, GameObject.Find("Canvas").transform);
        //    beatNo += beatpattern[patternNo];
        //    patternNo++;
        //}

        //if (patternNo >= beatpattern.Length)
        //{
        //    patternNo = 0;
        //}
    }
}
