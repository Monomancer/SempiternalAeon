﻿using UnityEngine;
using System;
using System.Collections;
using Pathfinding;


[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent (typeof(Seeker))]
public class MonsterAI : MonoBehaviour
{

	//What to chase
	public Transform target;

	//Path update rate
	public float updateRate = 2f;

	//Caching
	private Seeker seeker;
	private Rigidbody2D rb;

	// The calculated path
	public Path path;

	//The AI's speed per second
	public float speed = 300f;
	public ForceMode2D fMode;

	[HideInInspector]
	public bool pathIsEnded = false;

	//Max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 2;

	//Waypoint currently moving towards
	private int currentWaypoint = 0;

	//If monster is chasing or not
	bool active = false;

	//for Time.deltaTime calculations
	float time = 0;

	//true if monster is going right in passive mode
	bool rightDirection = true;

	//true if monster is facing right
	bool m_FacingRight = true;

	//animator
	Animator anim;

	void Start ()
	{
		seeker = GetComponent<Seeker> ();
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		if (target == null) {
			Debug.LogError ("No player found");
			return;
		}

		seeker.StartPath (transform.position, target.position, OnPathComplete);

		StartCoroutine (UpdatePath ());
	}

	IEnumerator UpdatePath ()
	{
		if (target == null) {
			//TODO: Insert player search / wandering behavior
			yield break;
		}

		//Create new path
		seeker.StartPath (transform.position, target.position, OnPathComplete);

		yield return new WaitForSeconds (1f / updateRate);
		StartCoroutine (UpdatePath ());
	}

	public void OnPathComplete (Path p)
	{
		//Debug.Log ("Path found. Error? " + path.error);
		if (!p.error) {
			path = p;
			currentWaypoint = 0;
		}
	}

	void FixedUpdate ()
	{
		

        
		if ((target == null || Math.Abs (target.position.magnitude - rb.position.magnitude) > 2) && !active) {
			if (Time.time - time > 4) {
				rightDirection = !rightDirection;
				time = Time.time;
			}
			if (rightDirection) {
				rb.velocity = new Vector3 (Math.Abs (speed / 90), 0, 0);
			} else {
				rb.velocity = new Vector3 ((-1) * Math.Abs (speed / 90), 0, 0);
			}

			//for flipping monster to face direction it is going in
			if (rb.velocity.x > 0 && !m_FacingRight) {
				// ... flip the player.
				Flip ();
			}
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (rb.velocity.x < 0 && m_FacingRight) {
				// ... flip the player.
				Flip ();
			}


			return;
		} else {
			active = true;

			if (target.position.x - rb.position.x >= 0) { // if true then player is to the right of monster
				if (!m_FacingRight) {
					Flip ();
				}
			} else { //player is to the left of monster
				if (m_FacingRight) {
					Flip ();
				}
			}

			//TODO: Always look at player?
			if (path == null)
				return;

			if (currentWaypoint >= path.vectorPath.Count) {
				if (pathIsEnded)
					return;
				Debug.Log ("End of path reached");
				pathIsEnded = true;
				return;
			}
			pathIsEnded = false;

			//Direction to next waypoint
			Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position).normalized;
			dir *= speed * Time.fixedDeltaTime;

			//for attacking
			/*if (Math.Abs (target.position.x - rb.position.x) < 1 && Math.Abs (target.position.y - rb.position.y) < 1) {
				anim.SetBool ("attack", true);
			} else {
				anim.SetBool ("attack", false);
			}*/

			//Move the AI
			rb.velocity = dir;
			float dist = Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]);
			if (dist < nextWaypointDistance) {
				currentWaypoint++;
				return;
			}



		}
	}

	private void Flip ()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}