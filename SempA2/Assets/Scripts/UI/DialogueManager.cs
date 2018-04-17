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
	public bool hasQuest = false;

	private string npc;
	private MonsterQuest monsterQuest;


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

			if (currentLine == (dialogueLines.Length - 1) && hasQuest) {
				if (Input.GetKeyDown (KeyCode.Y)) {
					this.AccceptQuest ();
					dialogueBox.SetActive (false);
					dialogueActive = false;
					currentLine = 0;
				} else if (Input.GetKeyDown (KeyCode.N)) {
					dialogueBox.SetActive (false);
					dialogueActive = false;
					currentLine = 0;
				}	
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

	public void ShowDialogueBox (string[] dialogue)
	{
		dialogueActive = true;
		dialogueBox.SetActive (true);
		dialogueText.text = dialogue [0];
		dialogueLines = dialogue;
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

	public void MonsterQuestOptional (MonsterQuest quest)
	{
		hasQuest = true;
		monsterQuest = quest;
	}

	private void AccceptQuest ()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<QuestManager> ().AddMonsterQuest (monsterQuest);
	}
}
