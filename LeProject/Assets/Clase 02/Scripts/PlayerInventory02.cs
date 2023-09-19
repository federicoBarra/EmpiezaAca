using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
	public string itemName;
	public ItemType itemType;

	public enum ItemType
	{
        Espada,
        Escudo,
	}
}

[Serializable]
public class PlayerInventoryData
{
	public List<Item> items;
}

public class PlayerInventory02 : MonoBehaviour
{
	[Header("Info del inventory")]
	public PlayerInventoryData data;

	//[Header("DEBUG")]
	[HideInInspector]
	public int zarlagna;
}
