using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGeneration : MonoBehaviour {

    public int questsCompleted;

    private void OnMouseDown()
    {
        if(questsCompleted == 0)
        {
            startingQuest();
        }
        else
        {
            generateNewQuest();
        }

    }

    private void startingQuest()
    {
        throw new NotImplementedException();
    }

    private void generateNewQuest()
    {
        throw new NotImplementedException();
    }
}
