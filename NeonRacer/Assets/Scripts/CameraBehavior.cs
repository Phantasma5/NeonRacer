using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    Camera cam;
    Vector3 average;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        average.x = 0;
        average.z = 0;
        for (int i = 0; i < References.players.Count; i++)
        {
            average.x += References.players[i].transform.position.x;
            average.z += References.players[i].transform.position.z;
        }
        cam.transform.position = average / 4;
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, average / 4, .5f);
    }
}
