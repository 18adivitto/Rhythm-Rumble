using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputUIElement : MonoBehaviour
{
    Vector3[] uiPosition;
    public int currentPosition = 0;

    int spawnBeat;

    //****just have it log what beatNo they spawned at, then have it reference the beat no to track its position. 

    void Awake()
    {
        spawnBeat = InputTracker.beatNo;
        if (InputTracker.player0Actions[spawnBeat] != null)// only works for Player 0 atm.
        {
            GetComponentInChildren<TextMeshProUGUI>().text = InputTracker.player0Actions[spawnBeat];
        }
        else
        {
            GetComponentInChildren<TextMeshProUGUI>().text = spawnBeat.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        uiPosition = new Vector3[4];

        uiPosition[0] = new Vector3(-350, 37, 0);
        uiPosition[1] = new Vector3(-350, 63, 0);
        uiPosition[2] = new Vector3(-350, 89, 0);
        uiPosition[3] = new Vector3(-350, 115, 0);
    }

    // Update is called once per frame
    void Update()
    {

        currentPosition = InputTracker.beatNo - spawnBeat;

        if (currentPosition > 3)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, uiPosition[currentPosition], Time.deltaTime * 15);
        }

        GetComponent<Image>().color = Color.Lerp(GetComponent<Image>().color, new Color(0,0,0,.6f), Time.deltaTime * 10);
    }
}
