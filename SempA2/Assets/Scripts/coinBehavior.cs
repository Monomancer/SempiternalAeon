using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class coinBehavior : MonoBehaviour {

    public Transform player;
    private Transform coin;

    // Use this for initialization
    void Start () {
        coin = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {

        if (Math.Abs(player.position.x - coin.position.x) < .1 && Math.Abs(player.position.x - coin.position.x) < .5)
        {
            CoinCounter.incrementCoinCount();
            Destroy(gameObject);
        }
		
	}
}
