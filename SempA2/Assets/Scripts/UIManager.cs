using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class UIManager : MonoBehaviour
{

	public Slider healthBar;
	public Text healthText;
	public PlayerHealthManager ph;
	public GameObject tabMenu;
	public Boolean inMenu = false;

	private static bool UIExists;

	// Use this for initialization
	void Start ()
	{
		if (!UIExists) {
			UIExists = true;

			// For whatever reason these cause UI elements to be deleted when reloading
			// scene rather than persisting
			//DontDestroyOnLoad (transform.gameObject);
		} else {
			//Destroy (gameObject); 
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthBar.maxValue = ph.playerMaxHealth;
		healthBar.value = ph.playerCurrentHealth;
		healthText.text = "HP: " + ph.playerCurrentHealth + "/" + ph.playerMaxHealth;

		if (inMenu) {
			tabMenu.SetActive (true);
		} else {
			tabMenu.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			inMenu = !inMenu;		
		}
	}

	public void CloseAllUI ()
	{
		inMenu = false;
		tabMenu.SetActive (false);


	}
}
