using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuImages : MonoBehaviour
{
    Vector3 activePos;
    Vector3 passivePos;

    Vector3 currentPos;
    // Start is called before the first frame update
    void Start()
    {
        activePos = new Vector3(235,0,0);
        passivePos = new Vector3(550,0,0);

        transform.localPosition = passivePos;
    }

    // Update is called once per frame
    void Update()
    {
        if (int.Parse(this.gameObject.name[0].ToString()) == OptionScroller.selectedOption)
        {
            currentPos = activePos;
        }
        else
        {
            currentPos = passivePos;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * 10);
    }
}
