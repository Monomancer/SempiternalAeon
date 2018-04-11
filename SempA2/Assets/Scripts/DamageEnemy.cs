using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{

	public int damage;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Enemy" && gameObject.tag == "Weapon") {
			other.gameObject.GetComponent<Animator> ().Play ("hit");
			other.gameObject.GetComponent<EnemyHealthManager> ().TakeDamage (damage);
			/*var clone = (GameObject)Instantiate (combatText);
			clone.transform.position = other.transform.position;
			clone.GetComponent<FloatingNumbers> ().damageNumber = damage;*/
		}
	}
}
