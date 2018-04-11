using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public float attackDelay;
	public GameObject combatText;

	// Use this for initialization
	void Start ()
	{
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void TakeDamage (int damage)
	{
		playerCurrentHealth -= damage;
		var clone = (GameObject)Instantiate (combatText);
		clone.transform.position = gameObject.transform.position;
		clone.GetComponent<FloatingNumbers> ().damageNumber = damage;
		clone.GetComponent<FloatingNumbers> ().setColor (Color.red);
		if (playerCurrentHealth <= 0) {
			SetMaxHealth ();
			Die (); 
		}
	}

	public void SetMaxHealth ()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	public void Die ()
	{
		Application.LoadLevel (Application.loadedLevel);

	}
}
