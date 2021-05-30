using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour
{
    Inventory inventory;
    InventorySlot[] slots;

    public Transform itemsParent;
    public GameObject inventoryUI;
    public GameObject buildModeUI;
    public bool isBuildMode = false;
    public static BasicUI instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }

        if (Input.GetButtonDown("Build mode"))
        {
            if (!isBuildMode)
            {
                isBuildMode = true;
            }
            else
            {
                isBuildMode = false;
            }
            buildModeUI.SetActive(!buildModeUI.activeSelf);
        }
    }

    void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i< inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
