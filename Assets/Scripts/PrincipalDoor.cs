using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincipalDoor : MonoBehaviour
{
    public GameObject player;
    public GameObject room1ExitDoor;

    public GameObject _light1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            this.player = coll.gameObject;
            List<GameObject> inventory = this.player.GetComponent<PlayerScript>().inventory;
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].GetComponent<ObjectCollision>().description == "Clé de Porte 1")
                {
                    this.GetComponent<SpriteRenderer>().color = Color.green;
                    this._light1.SetActive(true);
                    this.player.GetComponent<PlayerScript>().inventory.Remove(this.player.GetComponent<PlayerScript>().inventory[i]);
                    room1ExitDoor.GetComponent<SpriteRenderer>().color = Color.green;
                }
            }
        }
    }
}
