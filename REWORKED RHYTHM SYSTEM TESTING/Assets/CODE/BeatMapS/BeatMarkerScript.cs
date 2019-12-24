using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatMarkerScript : MonoBehaviour
{


    public GameObject Explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * 8/(BeatTracker.secPerBeat*2));

        if (transform.position == Vector3.zero)
        {
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
