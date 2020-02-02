using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2Exit : MonoBehaviour
{
    public Camera globalCam;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && this.GetComponent<SpriteRenderer>().color == Color.green)
        {
            if (globalCam.GetComponent<CameraController>().state == 1)
            {
                globalCam.GetComponent<CameraController>().state = 2;
                globalCam.GetComponent<Camera>().orthographicSize = 10.0f;
                coll.gameObject.transform.position = new Vector3(-8, 14, 0);
            }
            else if (globalCam.GetComponent<CameraController>().state == 2)
            {
                globalCam.GetComponent<CameraController>().state = 1;
                globalCam.GetComponent<Camera>().orthographicSize = 8.350795f;
                coll.gameObject.transform.position = new Vector3(-4, 14, 0);
            }
        }
    }
}
