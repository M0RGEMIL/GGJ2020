using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompteurElectrique : MonoBehaviour
{
    public GameObject door;

    private GameObject player;
    private bool repair = false;
    private bool colliding = false;

    public GameObject _light2;
    public GameObject _light3;

    void Start()
    {
        
    }

    void Update()
    {
        bool electric_wire = false;
        bool screwdriver = false;
        if (Input.GetKeyDown(KeyCode.E) && colliding == true)
        {
            List<GameObject> inventory = this.player.GetComponent<PlayerScript>().inventory;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetComponent<ObjectCollision>().name == "Tournevis")
                {
                    screwdriver = true;
                }
                if (inventory[i].GetComponent<ObjectCollision>().name == "fil_electrique")
                {
                    electric_wire = true;
                }
            }
            if (electric_wire != false && screwdriver != false)
            {
                repair = true;
                door.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
                this._light2.SetActive(true);
                this._light3.SetActive(true);
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].GetComponent<ObjectCollision>().name == "Tournevis" || inventory[i].GetComponent<ObjectCollision>().name == "fil_electrique")
                    {
                        this.player.GetComponent<PlayerScript>().inventory.Remove(this.player.GetComponent<PlayerScript>().inventory[i]);
                        i -= 1;
                    }
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && repair == false)
        {
            this.player = coll.gameObject;
            colliding = true;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player" && repair == false)
        {
            this.player = null;
            colliding = false;
        }
    }

}
