using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent (typeof(PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;
		private Rigidbody2D m_Rigidbody2D;

		private bool m_Jump;

		private bool basic_attack;
		private DialogueManager dMan;

		private void Awake ()
		{
			m_Character = GetComponent<PlatformerCharacter2D> ();
			dMan = FindObjectOfType<DialogueManager> ();
			m_Rigidbody2D = GetComponent<Rigidbody2D> ();
		}


		private void Update ()
		{
			if (!m_Jump) {
				// Read the jump input in Update so button presses aren't missed.
				m_Jump = CrossPlatformInputManager.GetButtonDown ("Jump");
                
			}
			if (!basic_attack) {
				basic_attack = CrossPlatformInputManager.GetButtonDown ("Basic_Attack");
			}

		}



		private void FixedUpdate ()
		{
			if (!dMan.dialogueActive) {
				// Read the inputs.
				bool crouch = Input.GetKey (KeyCode.CapsLock);
				float h = CrossPlatformInputManager.GetAxis ("Horizontal");
				// Pass all parameters to the character control script.
				m_Character.Move (h, crouch, m_Jump);
				m_Character.Basic_Attack (basic_attack, h);
				basic_attack = false;
				m_Jump = false;
			} else {
				m_Character.Move (0, false, m_Jump);
			}
		}
	}
}