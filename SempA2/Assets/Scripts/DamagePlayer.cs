using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
	public int damage;
	public Animator anim;

	// 0.5 && 0.2 respectively are decent for small mobs
	public float xDetection;
	public float yDetection;
	private float attackDelay;

	private Transform target;
	private Rigidbody2D rb;
	private bool inRange;

	// Use this for initialization
	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Math.Abs (target.position.x - rb.position.x) < xDetection && Math.Abs (target.position.y - rb.position.y) < yDetection) {
			anim.SetBool ("attack", true);
		} else {
			anim.SetBool ("attack", false);
		}			
		//anim.SetBool ("attacK", inRange);
		//Debug.Log (inRange);
		
	}

	/*void OnCollisionEnter2D (Collision2D collider)
	{
		if (collider.gameObject.name == "Player") {
			Debug.Log ("enter");

			inRange = true;
		}		
	}

	void OnCollisionExit2D (Collision2D collider)
	{
		if (collider.gameObject.name == "Player") {
			Debug.Log ("exit");
			inRange = false;
		}	

	}*/

	void AttackPlayer ()
	{
		target.GetComponent <PlayerHealthManager> ().TakeDamage (damage);
	}
}
