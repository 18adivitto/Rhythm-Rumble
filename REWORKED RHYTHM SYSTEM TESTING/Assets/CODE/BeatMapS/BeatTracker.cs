using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatTracker : MonoBehaviour
{
    public float songBpm;

    public float secPerBeat;


    public float songPosInBeats;

    public float songPosInSec;

    public float dspSongTime;

    //public float beatsInSong;

    AudioSource AS;

    private void Awake()
    {
        Destroy(GameObject.Find("MenuMusic"));
    }
    // Start is called before the first frame update
    void Start()
    {
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
            //determine how many seconds since the song started
            songPosInSec = 0;

            //determine how many beats since the song started
            songPosInBeats = 0;
            BeatSpawner.beatNo = 14.5f;
            AS.Play();
        }
    }
}
