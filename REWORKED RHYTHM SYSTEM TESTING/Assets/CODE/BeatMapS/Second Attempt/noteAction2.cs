using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteAction2 : MonoBehaviour
{

    float distFromCenter;
    BeatTracker BT;
    // Start is called before the first frame update
    void Start()
    {
        BT = GameObject.Find("MusicManager").GetComponent<BeatTracker>();
        if (int.Parse(this.gameObject.name[0].ToString()) == 0)
        {
            transform.localPosition = new Vector3(-400, 150, 0);
        }
        else
        {
            transform.localPosition = new Vector3(400, 150, 0);
        }
        distFromCenter = Mathf.Abs(0-transform.localPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, new Vector3(0, 150, 0), distFromCenter / (BT.secPerBeat * (250/1)));
        if (transform.localPosition.x == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
