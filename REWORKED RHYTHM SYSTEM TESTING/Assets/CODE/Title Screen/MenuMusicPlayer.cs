using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicPlayer : MonoBehaviour
{
    public float songBpm;

    public float secPerBeat;


    public float songPosInBeats;

    public float songPosInSec;

    public float dspSongTime;

    //public float beatsInSong;

    AudioSource AS;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        AS = GetComponent<AudioSource>();
        secPerBeat = 60f / songBpm;
        dspSongTime = (float)AudioSettings.dspTime;

        AS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (AS.isPlaying)
        {
            //determine how many seconds since the song started
            songPosInSec = (float)(AudioSettings.dspTime - dspSongTime);

            //determine how many beats since the song started
            songPosInBeats = songPosInSec / secPerBeat;
        }
        else
        {
            Debug.Log(BeatMapDebugging.MapZeroBeatTimes[0]);
        }
    }
}
