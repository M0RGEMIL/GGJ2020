using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastDoor : MonoBehaviour {
    public bool TV = false;
    public bool Gaz = false;
    public bool Lamp = false;
    public Camera globalCam;

    void Start () {

    }

    void Update () {
        if (this.TV && this.Gaz && this.Lamp) {
            globalCam.GetComponent<CameraController> ().state = 3;
            this.gameObject.GetComponent<SpriteRenderer> ().color = Color.green;

        }
    }

    void OnCollisionEnter2D (Collision2D coll) {
        if (this.TV && this.Gaz && this.Lamp) {
            Application.LoadLevel ("EndGame");
        }
    }
}