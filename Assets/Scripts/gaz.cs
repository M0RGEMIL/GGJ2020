using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gaz : MonoBehaviour
{
    public GameObject door;

    private GameObject player;
    private bool repaired = false;
    private bool colliding = false;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && colliding == true)
        {
            List<GameObject> inventory = this.player.GetComponent<PlayerScript>().inventory;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetComponent<ObjectCollision>().name == "briquet")
                {
                    repaired = true;
                    door.GetComponent<LastDoor>().Gaz = true;
                    this.player.GetComponent<PlayerScript>().inventory.Remove(this.player.GetComponent<PlayerScript>().inventory[i]);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && repaired == false)
        {
            this.player = coll.gameObject;
            colliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && repaired == false)
        {
            this.player = null;
            colliding = false;
        }
    }
}
