using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DamageEnemy : MonoBehaviour
{

	public int damage;
	private Boolean canAttack;

	// Use this for initialization
	void Start ()
	{
		canAttack = true;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (canAttack && other.gameObject.tag == "Enemy" && gameObject.tag == "Weapon") {
			canAttack = false;
			StartCoroutine (CanAttack ());
			Animator anim = other.gameObject.GetComponent<Animator> ();
			anim.Play ("hit");
			anim.SetBool ("wasHit", true);
			other.gameObject.GetComponent<EnemyHealthManager> ().TakeDamage (damage);
			gameObject.GetComponent<EdgeCollider2D> ().enabled = false;
		}
	}

	IEnumerator CanAttack ()
	{
		yield return new WaitForSeconds (1f);
		canAttack = true;
	}
}
