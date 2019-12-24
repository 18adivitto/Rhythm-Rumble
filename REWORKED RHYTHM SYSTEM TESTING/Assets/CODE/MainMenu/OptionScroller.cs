using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScroller : MonoBehaviour
{
    float rot;
    float rot1;

    public static int selectedOption;
    // Start is called before the first frame update
    void Start()
    {
        rot = 0;
        rot1 = 0;
        selectedOption = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuTransitions.subMenuActive)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rot += 45;
                selectedOption++;
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                rot -= 45;
                selectedOption--;
            }
        }
        if (selectedOption < 0)
        {
            selectedOption = 7;
        }
        if (selectedOption > 7)
        {
            selectedOption = 0;
        }

        rot1 = Mathf.Lerp(rot1, rot, Time.deltaTime * 12);

        transform.rotation = Quaternion.Euler(rot1,0,0);

        //Debug.Log(selectedOption + 1);
    }
}
