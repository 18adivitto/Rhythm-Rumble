using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    Image FADE;
    // Start is called before the first frame update
    void Start()
    {
        FADE = GetComponent<Image>();
        FADE.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        FADE.color = Color.Lerp(FADE.color, new Color(0,0,0,0), Time.deltaTime * 15);
    }
}
