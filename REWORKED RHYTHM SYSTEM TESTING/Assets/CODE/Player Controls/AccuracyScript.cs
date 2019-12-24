using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AccuracyScript : MonoBehaviour
{

    TextMeshPro text;
    bool goAway = false;
    Color textColor;
    Color textColorFade;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        transform.localPosition = new Vector3(0,1,0);
        textColor = new Color(text.color.r, text.color.g, text.color.b, 1.1f);
        textColorFade = new Color(text.color.r, text.color.g, text.color.b, -1f);

        text.color = textColorFade;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 1.5f, 0), Time.deltaTime * 5);
        if (text.color.a >= 1)
        {
            goAway = true;
        }

        if (goAway)
        {
            text.color = Color.Lerp(text.color, textColorFade, Time.deltaTime * 10);
        }
        else
        {
            text.color = Color.Lerp(text.color, textColor, Time.deltaTime * 15);
        }

        if (goAway && text.color.a < 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
