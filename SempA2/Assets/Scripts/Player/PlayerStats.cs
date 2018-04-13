using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int currentLevel;
	public int currentExp;
	public int expModifier;
    public static int batsKilled;

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
    }

    public int batsKilledgetter()
    {
        return batsKilled;
    }
}
