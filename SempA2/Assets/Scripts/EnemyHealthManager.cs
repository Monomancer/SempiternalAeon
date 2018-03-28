using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	Animator anim;


	// Use this for initialization
	void Start ()
	{
		enemyCurrentHealth = enemyMaxHealth;
		anim = GetComponent <Animator> ();
	}

	// Update is called once per frame
	void Update ()
	{
		if (enemyCurrentHealth <= 0) {
			/*GetComponent<DamagePlayer> ().enabled = false;
			GetComponent<MonsterAI> ().enabled = false;
			anim.SetBool ("attack", false);*/
			anim.Play ("die");
			Destroy (gameObject, 1f);

		}
	}

	public void TakeDamage (int damage)
	{
		enemyCurrentHealth -= damage;
	}

	public void OnTriggerEnter2D (Collider2D other)
	{
		Debug.Log (other.tag);
		if (other.tag == "Sword") {
			anim.Play ("hit");
			TakeDamage (10);
		}
	}
	/*public void OnCollisionEnter2D (Collision2D other)
	{
		Debug.Log (other.gameObject.tag);
		if (other.gameObject.tag == "Sword") {

		}
	}*/

	public void SetMaxHealth ()
	{
		enemyCurrentHealth = enemyMaxHealth;
	}

	public void Die ()
	{
		Destroy (gameObject);
	}
}