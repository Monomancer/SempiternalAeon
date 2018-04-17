using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework.Constraints;

public class DamagePlayer : MonoBehaviour
{
	public int damage;
	private Animator anim;
	private GameObject target;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player" && !anim.GetBool ("isDead") && !anim.GetBool ("wasHit") && !gameObject.GetComponent<MonsterAI> ().justSpawned) {
			anim.SetBool ("attack", true);
			anim.Play ("Attack");
		}
	}

	void OnCollisionStay2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player" && !anim.GetBool ("isDead") && !anim.GetBool ("wasHit") && !gameObject.GetComponent<MonsterAI> ().justSpawned) {
			anim.SetBool ("attack", true);
		}
	}

	void OnCollisionExit2D (Collision2D other)
	{
		if (other.gameObject.tag == "Player") {
			anim.SetBool ("attack", false);
		}	
	}


	void AttackPlayer ()
	{
		target.GetComponent <PlayerHealthManager> ().TakeDamage (damage);
	}
}
