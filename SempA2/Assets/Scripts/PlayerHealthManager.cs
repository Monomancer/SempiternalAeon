using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using System.Runtime.InteropServices;
using NUnit.Framework.Constraints;

public class PlayerHealthManager : MonoBehaviour
{

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public GameObject combatText;
	public float knockBackAmount;
	private bool canBeHit = true;

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
		if (canBeHit) {
			canBeHit = false;
			playerCurrentHealth -= damage;
			var clone = (GameObject)Instantiate (combatText);
			clone.transform.position = gameObject.transform.position;
			clone.GetComponent<FloatingNumbers> ().damageNumber = damage;
			clone.GetComponent<FloatingNumbers> ().setColor (Color.red);
			if (playerCurrentHealth <= 0) {
				SetMaxHealth ();
				Die (); 
				return;
			}		
			StartCoroutine (DelayAttacks ());
		}

		// Buggy implementation on player. Need to halt movement script until pushback over.
		float knockVelocity;
		if (gameObject.GetComponent<PlatformerCharacter2D> ().m_FacingRight) { 
			knockVelocity = knockBackAmount * -1;
		} else {
			knockVelocity = knockBackAmount;
		}
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockVelocity, 0f));
	}

	public void SetMaxHealth ()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	public void Die ()
	{
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		//Application.LoadLevel (Application.loadedLevel);
	}

	IEnumerator DelayAttacks ()
	{
		yield return new WaitForSeconds (1f);
		canBeHit = true;		
	}
}
