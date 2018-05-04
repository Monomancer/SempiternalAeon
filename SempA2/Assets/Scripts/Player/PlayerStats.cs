using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int currentLevel;
	public int currentExp;
	public int expModifier;
    private static int questBatsKilled;
    private static int batsKilled;
    private static bool onQuest;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentLevel == currentLevel * expModifier) {
			
		}
	}

    public void IncrementKills()
    {
        batsKilled++;
        Debug.Log("bats killed incremented");
        Debug.Log("bats killed = " + batsKilled);
        if (onQuest)
        {
            questBatsKilled++;
            Debug.Log("Quest bats killed = " + questBatsKilled);
        }
    }

    public int BatsKilledgetter()
    {
        return batsKilled;
    }
    public int QuestBatsKilledgetter()
    {
        return questBatsKilled;
    }


    public bool OnQuestgetter()
    {
        return onQuest;
    }
    public void OnQuestReset()
    {
        onQuest = false;
        questBatsKilled = 0;
    }
    public void OnQuestSetTrue()
    {
        onQuest = true;
    }
}
