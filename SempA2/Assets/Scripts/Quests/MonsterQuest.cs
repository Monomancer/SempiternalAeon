using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQuest : ScriptableObject
{
	
	public string monsterName;
	public int amount;
	public int experience;

	public MonsterQuest (string name, int amount, int experience)
	{
		this.monsterName = name;
		this.amount = amount;
		this.experience = experience;
	}

	public void CreateInstance (string name, int amount, int experience)
	{
		this.monsterName = name;
		this.amount = amount;
		this.experience = experience;
	}
}
