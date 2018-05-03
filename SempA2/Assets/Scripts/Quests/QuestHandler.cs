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
	public String monsterName;

	public int experience;
	private bool inDialogueRange = false;

    //updated version
    private int questProgress;
    private string questType;
    private int progressRequired;
    private int questsCompleted;

    // Use this for initialization
    void Start ()
	{
		dMan = FindObjectOfType<DialogueManager> ();
		Debug.Log ("dMan was found maybe");
	}


	private void OnMouseDown ()
	{
        questProgress = PlayerPrefs.GetInt("questProgress");
        questsCompleted = PlayerPrefs.GetInt("questsCompleted");
        progressRequired = 3 + (questsCompleted * 2);
        questType = PlayerPrefs.GetString("questType");
        Debug.Log("OnMouseDown hit");


		if (!dMan.dialogueActive) {
			dMan.ActivateDialogueBox ();
		}

		// QUEST STARTING SECTION


        //first check to see if the player is on a quest, if not create one
		if (questType == "false"){
			if (questStartDialogueArray.Length > 0) {
                DataController.myPlayer.QuestType = "monster";
                string batsKilledString = progressRequired + " bats";
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
        else if (questType == "monster" && DataController.myPlayer.QuestProgress < progressRequired) {
			if (questInProgressDialogueArray.Length > 0) {
				if (npcName.Length > 0) {
					dMan.ShowDialogueBox (questInProgressDialogueArray, npcName);
				} else {
					dMan.ShowDialogueBox (questInProgressDialogueArray);
				}
			}
		}

        //QUEST COMPLETED SECTION
        else if (questType == "monster" && questProgress >= progressRequired) {
            //reset the quest, give rewards, and whatever
            PlayerPrefs.SetInt("questProgress", 0);
            PlayerPrefs.SetInt("questsCompleted", PlayerPrefs.GetInt("questsCompleted") + 1);
            PlayerPrefs.SetString("questType", "false");


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

}
