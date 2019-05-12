using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class coinBehavior : MonoBehaviour {

	public Transform player;
	private Transform coin;
	float originalY;
	public float floatStrength = 2;

	// Use this for initialization
	void Start () {
		coin = GetComponent<Transform>();
		this.originalY = this.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,
			originalY + ((float)Math.Sin(Time.time) * floatStrength),
			transform.position.z);

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Player")  //player has collided with coin
		{
			CoinCounter.incrementCoinCount(); //add 1 coin to the coin count on the display (canvas)
			Destroy(gameObject); //destroy coin because we picked it up
		}
	}

	//updated once per frame
	private void FixedUpdate()
	{

	}

}
