using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour {

    public Transform player;
    private static Text coinText;
    private static int coinCount = 0;

	// Use this for initialization
	void Start () {
        coinText = GetComponent<Text>();
        coinText.text = "Coins: " + "0";

    }

    public static void incrementCoinCount() {
            coinCount++;
            coinText.text = "Coins: " + coinCount.ToString();
        
    }
}
