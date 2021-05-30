using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Equipment[] currentEquipment;

    Inventory inventory;
    PlayerStats playerStats;

    private void Start()
    {
        int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        currentEquipment = new Equipment[numberOfSlots];
        inventory = Inventory.instance;
        playerStats = PlayerStats.instance;
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipmentSlot;

        Equipment oldItem = null;

        if (currentEquipment[slotIndex] != null)
        {
            oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            playerStats.currentAttack -= oldItem.attack;
            playerStats.currentDefense -= oldItem.defense;
            playerStats.currentAttackRange = playerStats.defaultAttackRange;
        }

        playerStats.currentAttack += newItem.attack;
        playerStats.currentDefense += newItem.defense;
        playerStats.currentAttackRange = newItem.attackRange;

        currentEquipment[slotIndex] = newItem;
    }

    public void Unequip (int slotIndex)
    {
        if (currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = currentEquipment[slotIndex];
            inventory.Add(oldItem);

            currentEquipment[slotIndex] = null;

            playerStats.currentAttack -= oldItem.attack;
            playerStats.currentDefense -= oldItem.defense;
            playerStats.currentAttackRange = playerStats.defaultAttackRange;
        }
    }

    public void UnequipAll ()
    {
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            Unequip(i);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
            UnequipAll();
    }
}
