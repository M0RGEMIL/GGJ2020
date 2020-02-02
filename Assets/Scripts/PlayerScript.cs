using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public List<GameObject> inventory;
    private GameObject collGameObject;
    private GameObject dragGamObject;
    public bool drag = false;

    void Start()
    {
        collGameObject = null;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (collGameObject != null)
            {
                inventory.Add(collGameObject);
                collGameObject.SetActive(false);
                // ADD SOUND EFFECT HERE
            }
            else if (dragGamObject != null)
            {
                if (drag == false)
                {
                    dragGamObject.transform.parent = this.transform;
                    drag = true;
                }
                else
                {
                    dragGamObject.transform.parent = null;
                    drag = false;
                    dragGamObject = null;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "RoomObject")
        {
           collGameObject = coll.gameObject;
        }
        else if (coll.gameObject.tag == "DraggableObject")
        {
            dragGamObject = coll.gameObject;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        
        if (coll.gameObject.tag == "RoomObject")
        {
            collGameObject = null;
        }
        else if (coll.gameObject.tag == "DraggableObject")
        {
            dragGamObject = coll.gameObject;
        }
    }
}
