using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicNpcMovement : MonoBehaviour
{

	private Rigidbody2D mRigidBody;
	private SpriteRenderer mSpriteRenderer;

	public bool isWalking;
	public float moveSpeed;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int walkDirection = 1;
	private DialogueManager dMan;
	// Use this for initialization
	void Start ()
	{
		mRigidBody = GetComponent<Rigidbody2D> ();
		mSpriteRenderer = GetComponent<SpriteRenderer> ();
		walkCounter = walkTime;
		waitCounter = waitTime;
		dMan = FindObjectOfType<DialogueManager> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void FixedUpdate ()
	{
		if (!dMan.dialogueActive) {
			if (isWalking) {
				walkCounter -= Time.deltaTime;

				mRigidBody.velocity = new Vector2 (moveSpeed * walkDirection, mRigidBody.velocity.y);

				if (walkCounter < 0) {
					isWalking = false;
					waitCounter = waitTime;
				}

			} else {
				mRigidBody.velocity = Vector2.zero;
				waitCounter -= Time.deltaTime;
				if (waitCounter < 0) {
					ChooseDirection ();
				}

			}
		} else {
			Debug.Log ("in");
			isWalking = false;
			mRigidBody.velocity = Vector2.zero;
		}
	}

	public void ChooseDirection ()
	{
		walkDirection = walkDirection == -1 ? 1 : -1;
		mSpriteRenderer.flipX = !mSpriteRenderer.flipX;
		isWalking = true;
		walkCounter = walkTime;
		
	}
}
