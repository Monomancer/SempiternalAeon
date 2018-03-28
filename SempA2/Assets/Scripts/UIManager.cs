using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public Slider healthBar;
	public Text healthText;
	public PlayerHealthManager ph;

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
	}
}
