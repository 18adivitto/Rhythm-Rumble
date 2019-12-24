using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreenManager : MonoBehaviour
{

    public GameObject TitleText;
    public GameObject TitleTextFade;
    public GameObject FightStickGraphic;
    public GameObject FightFade;

    bool debugStart = false;
    bool Pulsed = false;
    Vector3 textPosStart;
    Vector3 stickPosStart;

    bool graphicsEntered = false;

    bool goUp = false;

    float textSpeed = .5f;

    MenuMusicPlayer menuMusic;

    float Beat = 1;

    public GameObject PS;

    bool graphicsSet = false;

    public Image FADE;
    bool changeScene = false;
    // Start is called before the first frame update
    void Start()
    {
        textPosStart = new Vector3(0,-7,-.1f);
        stickPosStart = new Vector3(0,10,0);
        TitleText.transform.position = textPosStart;
        FightStickGraphic.transform.position = stickPosStart;

        TitleText.GetComponent<SpriteRenderer>().color = Color.black;
        FightStickGraphic.GetComponent<SpriteRenderer>().color = Color.black;

        menuMusic = GameObject.Find("MenuMusic").GetComponent<MenuMusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        PS.SetActive(Pulsed);
        textSpeed = Mathf.Abs(TitleText.transform.position.y) * 2;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            debugStart = true;
        }

        if (menuMusic.songPosInBeats > 1)
        {
            debugStart = true;
        }

        if (debugStart)
        {
            TitleText.GetComponent<SpriteRenderer>().color = Color.Lerp(TitleText.GetComponent<SpriteRenderer>().color, Vector4.one, Time.deltaTime * 7);
            FightStickGraphic.GetComponent<SpriteRenderer>().color = Color.Lerp(FightStickGraphic.GetComponent<SpriteRenderer>().color, Vector4.one, Time.deltaTime * 7);

            if (Mathf.Abs(TitleText.transform.position.y) < .1f)
            {
                if (!Pulsed)
                {
                    PulseFade();
                }
                else
                {
                    
                }
                goUp = false;
            }
            if (!Pulsed)
            {
                if (Mathf.Abs(FightStickGraphic.transform.position.y) < .1f)
                {
                    TitleText.transform.position = Vector3.Lerp(TitleText.transform.position, new Vector3(0,0, -.1f), Time.deltaTime * 15);
                }
                FightStickGraphic.transform.position = Vector3.Lerp(FightStickGraphic.transform.position, Vector3.zero, Time.deltaTime * 15);
            }

            if (Mathf.Abs(TitleText.transform.position.y) > .9f)
            {
                goUp = true;
            }

            if (Pulsed)
            {
                Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5, Time.deltaTime * 5);
                if (goUp)
                {
                    TitleText.transform.position = Vector3.MoveTowards(TitleText.transform.position, new Vector3(0, 0, -.1f), Time.deltaTime * textSpeed);
                }
                else
                {
                    TitleText.transform.position = Vector3.MoveTowards(TitleText.transform.position, new Vector3(0, -1, -.1f), Time.deltaTime * textSpeed);
                }
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                changeScene = true;
            }

            if (changeScene)
            {
                FADE.color = Color.Lerp(FADE.color, new Color(1, 1, 1, 1.1f), Time.deltaTime * 20);
            }

            if (FADE.color.a > 1)
            {
                SceneManager.LoadScene("Main Menu");
            }

            if (Pulsed) //pulse to the beat
            {
                if (!graphicsSet)
                {
                    //Beat = Mathf.RoundToInt(menuMusic.songPosInBeats) + 1;
                    Beat = 8;
                    graphicsSet = true;
                }

                if (menuMusic.songPosInBeats > Beat)
                {
                    Camera.main.orthographicSize = 6f;
                    //Instantiate(TitleTextFade, TitleText.transform.position, Quaternion.identity);
                    Instantiate(FightFade, FightStickGraphic.transform.position + new Vector3(0,0,1f), Quaternion.identity);
                    Beat++;
                }
            }
        }
    }

    void PulseFade()
    {
        if (!Pulsed)
        {
            //Camera.main.orthographicSize = 6;
            //Instantiate(TitleTextFade, TitleText.transform.position, Quaternion.identity);
            //Instantiate(FightFade, FightStickGraphic.transform.position, Quaternion.identity);
            Pulsed = true;
        }
    }
}
