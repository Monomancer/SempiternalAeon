using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography.X509Certificates;
using System;
using UnityEditor.VersionControl;

public class QuestHandler : MonoBehaviour
{

    public string npcName;
    public string[] dialogueArray;
    private DialogueManager dMan;
    public bool hasMonsterQuest = false;
    public String monsterName;
    public int amount, experience;
    private bool inDialogueRange = false;

    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        Debug.Log("dMan was found maybe");
    }


    private void OnMouseDown()
    {
        Debug.Log("trigger hit");
        if (!dMan.dialogueActive)
        {
            dMan.ActivateDialogueBox();
        }
        if (dialogueArray.Length > 0)
        {
            if (npcName.Length > 0)
            {
                dMan.ShowDialogueBox(dialogueArray, npcName);
            }
            else
            {
                dMan.ShowDialogueBox(dialogueArray);
            }
        }

    }


    public MonsterQuest GetQuest()
    {
        return null;
    }
}
