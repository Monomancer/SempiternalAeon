using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public float attackDelay;


	// Use this for initialization
	void Start ()
	{
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerCurrentHealth <= 0) {
			//gameObject.SetActive (false);
			SetMaxHealth ();
			Application.LoadLevel (Application.loadedLevel);
			//GameManager.reload or spawn


		}
	}

	public void TakeDamage (int damage)
	{
		playerCurrentHealth -= damage;
	}

	public void SetMaxHealth ()
	{
		playerCurrentHealth = playerMaxHealth;
	}
}
