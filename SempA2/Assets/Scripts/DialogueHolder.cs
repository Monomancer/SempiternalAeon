using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

	public string npcName;
	public string dialogue;
	public string[] dialogueArray;
	private DialogueManager dMan;
	public bool inDialogueRange = false;

	// Use this for initialization
	void Start ()
	{
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (inDialogueRange) {
			if (Input.GetKeyDown (KeyCode.E)) { 
				if (!dMan.dialogueActive) {
					dMan.ActivateDialogueBox ();
				}
				if (dialogue.Length > 0 && dialogueArray.Length > 0) {
					Debug.Log ("More than one dialogue size!"); 
				} else if (dialogue.Length > 0) { 
					if (npcName.Length > 0) {
						dMan.ShowDialogueBox (dialogue, npcName);
					} else {
						dMan.ShowDialogueBox (dialogue);
					}
				} else {
					if (npcName.Length > 0) {
						dMan.ShowDialogueBox (dialogueArray, npcName);
					} else {
						dMan.ShowDialogueBox (dialogueArray);
					}
				}
			}
		}
	}

	/*void OnTriggerStay2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) { 
				if (!dMan.dialogueActive) {
					dMan.ActivateDialogueBox ();
				}
				if (dialogue.Length > 0 && dialogueArray.Length > 0) {
					Debug.Log ("More than one dialogue size!"); 
				} else if (dialogue.Length > 0) { 
					dMan.ShowDialogueBox (dialogue);
				} else {
					dMan.ShowDialogueBox (dialogueArray);
				}
			}
		}
	}*/

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			inDialogueRange = true;	
		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.gameObject.name == "Player") {
			inDialogueRange = false;	
		}
	}
}
