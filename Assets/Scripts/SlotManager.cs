using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public List<GameObject> inventory;
    public GameObject player;
    public GameObject slotPrefab;

    private int slotX = -65;
    private int slotOffset = 44;
    int colsCount = 0;
    int oldColsCount = 0;

    void Awake()
    {
        Global.slotManager = this;    
    }

    void Start()
    {
        gameObject.GetComponent<HingeJoint>();
    }

    void Update()
    {

        this.colsCount = player.GetComponent<PlayerScript>().inventory.Count;
        if (this.colsCount !=  this.oldColsCount)
        {
            this.inventory = null;
            this.inventory = player.GetComponent<PlayerScript>().inventory;
            ClearChildren();
            CreateSlots();
            this.oldColsCount = this.colsCount;
        }

    }

    public void ClearChildren()
    {
         slotX = -65;
        int i = 0;

        GameObject[] allChildren = new GameObject[transform.childCount];

        foreach (Transform child in transform)
        {
            allChildren[i] = child.gameObject;
            i += 1;
        }

        foreach (GameObject child in allChildren)
        {
            DestroyImmediate(child.gameObject);
        }
    }

    public void CreateSlots()
    {
        if (slotPrefab == null)
            Debug.LogError("Erreur: slot Prefab est null");
        else
        {
            for (int i = 0; i < colsCount; i++)
            {
                GameObject currentSlot = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity) as GameObject;
                currentSlot.transform.GetChild(1).GetComponent<UnityEngine.UI.Image>().sprite = this.inventory[i].GetComponent<SpriteRenderer>().sprite;
                currentSlot.transform.SetParent(transform, false);

                RectTransform rectTransform = currentSlot.GetComponent<RectTransform>();
                rectTransform.localPosition = new Vector3(slotX, 0, 0);
                slotX += slotOffset;
            }
        }
    }
}
