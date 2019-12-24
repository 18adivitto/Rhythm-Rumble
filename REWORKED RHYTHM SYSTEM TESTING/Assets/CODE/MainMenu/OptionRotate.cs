using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionRotate : MonoBehaviour
{
    SpriteRenderer SR;
    float lightness;
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        lightness = 1 - ((transform.position.z + 2.5f) / 5);
        //lightness *= 100;
        //lightness = Mathf.Round(lightness);
        if (this.gameObject.name == "Option (0)")
        {
            //Debug.Log(lightness);
        }
        

        transform.localScale = new Vector3(2*lightness,.3f*lightness, 1);


        SR.color = Color.HSVToRGB(.18f,1,lightness);
        
    }
}
