using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	public int damage;
	private Animator anim;

	// 0.5 && 0.2 respectively are decent for small mobs
	public float xDetection;
	public float yDetection;
	private float attackDelay;

	private GameObject target;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{		
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Player") {
			anim.SetBool ("attack", true);
			anim.Play ("Attack");
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		if (other.tag == "Player") {
			anim.SetBool ("attack", true);
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
			anim.SetBool ("attack", false);
		}	
	}

	void AttackPlayer ()
	{
		//Debug.Log (target.tag);
		target.GetComponent <PlayerHealthManager> ().TakeDamage (damage);
	}
}
