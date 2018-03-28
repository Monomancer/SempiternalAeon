using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{

	public GameObject dialogueBox;
	public Text dialogueText;

	public bool dialogueActive;

	public string[] dialogueLines;
	public int currentLine;

	private string npc;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (dialogueActive) {

			if (Input.GetMouseButtonDown (0)) {
				currentLine++;
			} else if (Input.GetMouseButtonDown (1) && currentLine > 0) {
				currentLine--;
			}

			if (Input.GetKeyDown (KeyCode.Space) || currentLine >= dialogueLines.Length) {
				dialogueBox.SetActive (false);
				dialogueActive = false;
				currentLine = 0;
			}

			if (npc.Length > 0)
				dialogueText.text = npc + ": " + dialogueLines [currentLine];
			else
				dialogueText.text = dialogueLines [currentLine];
			
		}
	}

	public void ShowDialogueBox (string dialogue)
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
		dialogueText.text = dialogue;
	}

	public void ShowDialogueBox (string[] dialogue)
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
		dialogueText.text = dialogue [0];
		dialogueLines = dialogue;
	}

	public void ShowDialogueBox (string dialogue, string npcName)
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
		npc = npcName;
		dialogueText.text = npcName + ": " + dialogue;
	}

	public void ShowDialogueBox (string[] dialogue, string npcName)
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
		dialogueText.text = npcName + ": " + dialogue [0];
		npc = npcName;
		dialogueLines = dialogue;
	}

	public void ActivateDialogueBox ()
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
	}

	public bool IsActive ()
	{
		return dialogueActive;

	}
}
