using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using System;

public class DialogueHolder : MonoBehaviour
{

	public string npcName;
	public string[] dialogueArray;
	private DialogueManager dMan;
	public bool hasMonsterQuest = false;
	public String monsterName;
	public int amount, experience;
	private bool inDialogueRange = false;

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
				/*if (hasMonsterQuest) {
					dMan.MonsterQuestOptional (ScriptableObject.CreateInstance (name, amount, experience));
				}*/
				if (!dMan.dialogueActive) {
					dMan.ActivateDialogueBox ();
				}
				if (dialogueArray.Length > 0) { 
					if (npcName.Length > 0) {
						dMan.ShowDialogueBox (dialogueArray, npcName);
					} else {
						dMan.ShowDialogueBox (dialogueArray);
					}
				}
			}
		}
	}

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

	public MonsterQuest GetQuest ()
	{
		return null;
	}
}
