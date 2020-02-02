using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public static SlotManager slotManager;

    void Start()
    {
        slotManager.CreateSlots();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
