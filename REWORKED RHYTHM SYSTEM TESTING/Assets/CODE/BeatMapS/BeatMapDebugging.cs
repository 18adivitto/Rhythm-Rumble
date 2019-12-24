using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMapDebugging : MonoBehaviour
{
    public static string[] MapZeroNames;
    public static float[] MapZeroBeatTimes;

    int beatNo = 0;

    void Awake()
    {
        //PlayerPrefs.DeleteAll();
        MapZeroNames = new string[288];

        for (int i = 0; i < MapZeroNames.Length; i++)
        {
            MapZeroNames[i] = "beat" + i.ToString();
        }

        MapZeroBeatTimes = new float[288];
        for (int i = 0; i < MapZeroBeatTimes.Length; i++)
        {
            MapZeroBeatTimes[i] = PlayerPrefs.GetFloat("beat" + i.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        beatNo = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log(Mathf.Round(BeatTracker.songPosInBeats * 2) / 2);
            //PlayerPrefs.SetFloat("beat" + beatNo.ToString(), Mathf.Round(BeatTracker.songPosInBeats * 2) / 2);
            //PlayerPrefs.Save();
            //beatNo++;
        }


    }
}
