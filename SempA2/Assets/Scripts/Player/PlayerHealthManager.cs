using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;
using System.Runtime.InteropServices;
using System.IO;

public class PlayerHealthManager : MonoBehaviour
{

	public int playerMaxHealth;
	public int playerCurrentHealth;
	public GameObject combatText;
	public float knockBackAmount;
	private bool canBeHit = true;
	private SpriteRenderer spriteRend;

	// Use this for initialization
	void Start ()
	{
		playerCurrentHealth = playerMaxHealth;
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
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
			HitColorChange ();
			if (playerCurrentHealth <= 0) {
				gameObject.GetComponent<Animator> ().SetBool ("Is_Dead", true);
				gameObject.GetComponent<Animator> ().Play ("Die");
				StartCoroutine (DelayDeath ());
				return;
			}		
			StartCoroutine (DelayAttacks ());
		}

		// Buggy implementation on player. Need to halt movement script until pushback over.
		/*float knockVelocity;
		if (gameObject.GetComponent<PlatformerCharacter2D> ().m_FacingRight) { 
			knockVelocity = knockBackAmount * -1;
		} else {
			knockVelocity = knockBackAmount;
		}
		gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (knockVelocity, 0f));*/
	}

	public void HitColorChange ()
	{
		Color col = spriteRend.color;
		StartCoroutine (ReturnOriginalColors (col));
		col.b -= 90;
		col.g -= 90;
		spriteRend.color = col;
	}

	IEnumerator ReturnOriginalColors (Color color)
	{
		yield return new WaitForSeconds (0.5f); 
		spriteRend.color = color;
	}

	public void SetMaxHealth ()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	public void Die ()
	{
		gameObject.GetComponent<Animator> ().SetBool ("Is_Dead", false);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}

	IEnumerator DelayAttacks ()
	{
		yield return new WaitForSeconds (1f);
		canBeHit = true;		
	}

	IEnumerator DelayDeath ()
	{
		canBeHit = false;
		yield return new WaitForSeconds (3f);
		canBeHit = true;
		SetMaxHealth ();
		Die (); 
	}
}
