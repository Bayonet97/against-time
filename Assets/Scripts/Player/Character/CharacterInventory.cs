using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class CharacterInventory : MonoBehaviour
{
    public int WoodAmount { get; private set; } = 0;
    public bool HasAxe { get; private set; } = false;
    public bool HasKey { get; private set; } = false;
    public bool HasWheelbarrow { get; private set; } = false;

    public delegate void InteractAction();
    public static event InteractAction OnInventoryChanged;

    public void AddWood()
    {
        WoodAmount++;
        OnInventoryChanged();
    }

    public void DeleteWood()
    {
        WoodAmount--;
        OnInventoryChanged();
    }

    public void ObtainAxe()
    {
        HasAxe = true;
        OnInventoryChanged();
    }
    public void ObtainKey()
    {
        HasKey = true;
        OnInventoryChanged();
    }
    public void ObtainWheelbarrow()
    {
        HasWheelbarrow = true;
         OnInventoryChanged();
    }
}