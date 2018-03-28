using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
	[RequireComponent (typeof(PlatformerCharacter2D))]
	public class Platformer2DUserControl : MonoBehaviour
	{
		private PlatformerCharacter2D m_Character;

		private bool m_Jump;

		private bool basic_attack;
		private DialogueManager dMan;
		private PauseMenu pMenu;
		private bool crouch;
		private float h;


		private void Awake ()
		{
			m_Character = GetComponent<PlatformerCharacter2D> ();
			dMan = FindObjectOfType<DialogueManager> ();
			pMenu = FindObjectOfType<PauseMenu> ();
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

			if (!dMan.dialogueActive && !pMenu.isPaused) {
				crouch = Input.GetKey (KeyCode.CapsLock);
				h = CrossPlatformInputManager.GetAxis ("Horizontal");
			} else {
				crouch = basic_attack = m_Jump = false;
				h = 0;
			}

		}

		private void FixedUpdate ()
		{
			// Pass all parameters to the character control script.
			m_Character.Move (h, crouch, m_Jump);
			m_Character.Basic_Attack (basic_attack, h);
			basic_attack = false;
			m_Jump = false;
		}
	}
}
