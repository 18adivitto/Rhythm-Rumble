using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPulse : MonoBehaviour
{
    Light stageLight;
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
        stageLight = GetComponent<Light>();
        beatNo = 0f;
    }
    //on latin beat it goes .5, 1.25, 1.5, 2.5
    // so thats a gap of .75, .75, .25, 1


    // Update is called once per frame
    void Update()
    {
        if (BT.songPosInBeats > beatNo)
        {
            stageLight.color = Color.yellow;
            beatNo++;
        }

        //if (BT.songPosInBeats > beatNo)
        //{
        //    stageLight.color = Color.yellow;
        //    beatNo += beatpattern[patternNo];
        //    patternNo++;
        //}

        //if (patternNo >= beatpattern.Length)
        //{
        //    patternNo = 0;
        //}

        stageLight.color = Color.Lerp(stageLight.color, Color.white, Time.deltaTime * 10);
    }
}
