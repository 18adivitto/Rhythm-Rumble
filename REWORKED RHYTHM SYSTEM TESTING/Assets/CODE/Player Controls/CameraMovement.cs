using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform[] player;
    Vector3 CamPos;

    public float playerDist;
    // Start is called before the first frame update
    void Start()
    {
        player = new Transform[2];
        player[0] = GameObject.Find("0Player").transform;
        player[1] = GameObject.Find("1Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CamPos.x = player[1].position.x + ((Vector3.Distance(new Vector3(player[0].position.x, 0, 0), new Vector3(player[1].position.x, 0, 0)) / 2) * (-(player[1].position.x - player[0].position.x) / Mathf.Abs((player[1].position.x - player[0].position.x))));
        CamPos.z = -9.11f;
        CamPos.y = 1 + Vector3.Distance(new Vector3(0,player[0].position.y,0),new Vector3(0,player[1].position.y,0)) / 2;
        transform.position = Vector3.Lerp(transform.position, CamPos, Time.deltaTime * 10);
        playerDist = Vector3.Distance(player[0].position, player[1].position);
        //Debug.Log(playerDist);
    }
}
