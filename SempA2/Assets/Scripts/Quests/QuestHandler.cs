using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestHandler : MonoBehaviour
{

	public string npcName;
	public string[] questStartDialogueArray;
	public string[] questInProgressDialogueArray;
	public string[] questCompletedDialogueArray;
	public string[] questErrorDialogueArray;
	private DialogueManager dMan;
	public bool hasMonsterQuest = false;
	public String monsterName;
	public int killsRequired;
	public int experience;
	private bool inDialogueRange = false;

	// Use this for initialization
	void Start ()
	{
		dMan = FindObjectOfType<DialogueManager> ();
		Debug.Log ("dMan was found maybe");
	}


	private void OnMouseDown ()
	{
		var batsKilled = GameObject.FindGameObjectWithTag ("UICanvas").GetComponent<PlayerStats> ().BatsKilledgetter ();
		var questBatsKilled = GameObject.FindGameObjectWithTag ("UICanvas").GetComponent<PlayerStats> ().QuestBatsKilledgetter ();
		hasMonsterQuest = GameObject.FindGameObjectWithTag ("UICanvas").GetComponent<PlayerStats> ().OnQuestgetter ();
		Debug.Log ("trigger hit");
		Debug.Log ("batskilled = " + batsKilled);
		Debug.Log ("questbatsKilled = " + questBatsKilled);


		if (!dMan.dialogueActive) {
			dMan.ActivateDialogueBox ();
		}

		// QUEST STARTING SECTION

		if (hasMonsterQuest == false) {
			if (questStartDialogueArray.Length > 0) {
				GameObject.FindGameObjectWithTag ("UICanvas").GetComponent<PlayerStats> ().OnQuestSetTrue ();
				string batsKilledString = killsRequired + " bats";
				questStartDialogueArray [4] += batsKilledString;
				//start tracking kills required by taking kills required and adding it to the kills we completed before being assigned the quest
				if (npcName.Length > 0) {
					dMan.ShowDialogueBox (questStartDialogueArray, npcName);
				} else {
					dMan.ShowDialogueBox (questStartDialogueArray);
				}
			}
		}


        // QUEST IN PROGRESS SECTION
        else if (hasMonsterQuest == true && questBatsKilled < killsRequired) {
			if (questInProgressDialogueArray.Length > 0) {
				if (npcName.Length > 0) {
					dMan.ShowDialogueBox (questInProgressDialogueArray, npcName);
				} else {
					dMan.ShowDialogueBox (questInProgressDialogueArray);
				}
			}
		}

        //QUEST COMPLETED SECTION
        else if (hasMonsterQuest == true && questBatsKilled >= killsRequired) {
			//reset the quest, give rewards, and whatever
			GameObject.FindGameObjectWithTag ("UICanvas").GetComponent<PlayerStats> ().OnQuestReset ();
			killsRequired += 2;

			if (questCompletedDialogueArray.Length > 0) {
				if (npcName.Length > 0) {
					dMan.ShowDialogueBox (questCompletedDialogueArray, npcName);
				} else {
					dMan.ShowDialogueBox (questCompletedDialogueArray);
				}
			}
		}

        //this else statement should never be reached. 
        else {
			if (questErrorDialogueArray.Length > 0) {
				if (npcName.Length > 0) {
					dMan.ShowDialogueBox (questErrorDialogueArray, npcName);
				} else {
					dMan.ShowDialogueBox (questErrorDialogueArray);
				}
			}

		}






	}


	public MonsterQuest GetQuest ()
	{
		return null;
	}
}
