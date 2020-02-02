using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;

    void Update()
    {
        if (this.gameObject.GetComponent<PlayerScript>().drag == true)
            speed = 1.0f;
        else
            speed = 10.0f;
        float Y = Input.GetAxis("Vertical") * speed;
        float X = Input.GetAxis("Horizontal") * speed;

        Y *= Time.deltaTime;
        X *= Time.deltaTime;
        if (this.gameObject.GetComponent<PlayerScript>().drag != true)
            ChangeSprite(X, Y);
        this.transform.Translate(X, Y, 0);
    }

    void ChangeSprite(float X, float Y)
    {
        this.transform.GetChild(0).transform.rotation = Quaternion.identity;
        if (X < 0 && Y == 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, 90);
       } else if (X < 0 && Y < 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, 135);
        } else if (X < 0 && Y > 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, 45);
        } else if (X > 0 && Y == 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, -90);
        }
        else if (X > 0 && Y < 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, -135);
        }
        else if (X > 0 && Y > 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, -45);
        }
        else if (X == 0 && Y < 0)
        {
            this.transform.GetChild(0).transform.Rotate(0, 0, 180);
        }
    }
}