using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public int state = 0;
    public GameObject _light4;

    public Text txt;

    void Start()
    {
        
    }

    void Update()
    {
        if (state == 0)
        {
            txt.text = "A faire :\n- faites entrez la lumière";
            this.transform.position = new Vector3(0, 0, -10);
        }
        else if (state == 1)
        {
            txt.text = "A faire :\n- trouvez le tournevis\n- trouvez le fil manquant\n- réparez le boitier électrique";
            this.transform.position = new Vector3(1, 12, -10);
        }
        else if (state == 2)
        {
            txt.text = "A faire :\n- réparez la télé\n- réparez la gazinière\n- réparez la lampe";
            this.transform.position = new Vector3(-12, 9, -10);
        }
        else if (state == 3)
        {
            this._light4.SetActive(true);
            this.transform.position = new Vector3(-12, 9, -10);
        }
    }
}
