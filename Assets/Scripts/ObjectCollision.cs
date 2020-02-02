using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public GameObject collision_object;
    public string description;

    void Start()
    {
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && collision_object != null)
        {
            collision_object.SetActive(true);
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && collision_object != null)
        {
            collision_object.SetActive(false);
        }
    }
}
