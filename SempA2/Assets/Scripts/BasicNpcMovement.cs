using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicNpcMovement : MonoBehaviour
{

	private Rigidbody2D mRigidBody;
	private SpriteRenderer mSpriteRenderer;
	public Animator m_Anim;

	public bool isWalking;
	public float moveSpeed;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private int walkDirection = 1;
	private DialogueManager dMan;

	void Start ()
	{
		mRigidBody = GetComponent<Rigidbody2D> ();
		mSpriteRenderer = GetComponent<SpriteRenderer> ();
		walkCounter = walkTime;
		waitCounter = waitTime;
		dMan = FindObjectOfType<DialogueManager> ();
		m_Anim = GetComponent<Animator> ();

	}

	void Update ()
	{
		
	}

	void FixedUpdate ()
	{
		if (!dMan.dialogueActive) {
			if (isWalking) {
				walkCounter -= Time.deltaTime;

				//Move NPC
				mRigidBody.velocity = new Vector2 (moveSpeed * walkDirection, mRigidBody.velocity.y);
				m_Anim.SetFloat ("Speed", 1);

				if (walkCounter < 0) {
					isWalking = false;
					m_Anim.SetFloat ("Speed", 0);
					waitCounter = waitTime;
				}

			} else {
				//Idle NPC
				mRigidBody.velocity = Vector2.zero;
				waitCounter -= Time.deltaTime;
				if (waitCounter < 0) {
					ChooseDirection ();
				}

			}
		} else {
			//Player is in dialogue with NPC, turn towards player
			gameObject.GetComponent<SpriteRenderer> ().flipX = !GameObject.FindGameObjectWithTag ("Player").GetComponent<SpriteRenderer> ().flipX;

			m_Anim.SetFloat ("Speed", 0);
			isWalking = false;
			waitCounter = waitTime;
			mRigidBody.velocity = Vector2.zero;
		}
	}

	public void ChooseDirection ()
	{
		walkDirection = walkDirection == -1 ? 1 : -1;

		//Make sure NPC is facing correct direction
		if (walkDirection < 0) {
			mSpriteRenderer.flipX = true;
		} else {
			mSpriteRenderer.flipX = false;
		}
		isWalking = true;
		walkCounter = walkTime;
		
	}
}
