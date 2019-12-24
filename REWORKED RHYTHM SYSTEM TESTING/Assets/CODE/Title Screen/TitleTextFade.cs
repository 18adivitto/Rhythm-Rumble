using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleTextFade : MonoBehaviour
{
    SpriteRenderer SR;
    
    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        SR.color = new Color(1,1,1,0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(5,5,1), Time.deltaTime * 5);
        SR.color = Color.Lerp(SR.color, new Color(1,1,1,0), Time.deltaTime * 7);

        if (SR.color.a < .1f)
        {
            Destroy(this.gameObject);
        }
    }
}
