using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public List<Item> inventory = new List<Item> ();
	private ItemDatabase database;

	void Start ()
	{
		database = GameObject.FindGameObjectWithTag ("Item Database").GetComponent<ItemDatabase> ();
		inventory.Add (database.items [0]);
	}

	void OnGUI ()
	{
		for (int i = 0; i < inventory.Count; i++) {
			GUI.Label (new Rect (10, 10, 200, 50), inventory [i].itemName); 	
		}
	}
}
