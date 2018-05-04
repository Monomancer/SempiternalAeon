using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{

	//to reference text in canvas coin object
	private static Text coinText;

	//count for number of coins
	

	// Use this for initialization
	void Start ()
	{
		coinText = GetComponent<Text> (); //get text object
		coinText.text = "Coins: " + DataController.myPlayer.Coins; //set display to 0 coins

	}

	public static void incrementCoinCount ()
	{
        DataController.myPlayer.Coins++; //increment coin count
		coinText.text = "Coins: " + DataController.myPlayer.Coins.ToString (); //set display to new coin count
        
	}
}
