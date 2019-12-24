using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatSpawner : MonoBehaviour
{

    public static float beatNo;
    public GameObject beatMarker;

    // Start is called before the first frame update
    void Start()
    {
        beatNo = 14.5f;
    }

    // Update is called once per frame
    void Update()
    {

        //if (BeatTracker.songPosInBeats >= beatNo)
        //{
        //    Instantiate(beatMarker, new Vector3(-8, 0, 0), Quaternion.identity);
        //    beatNo++;
        //}

    }
}
