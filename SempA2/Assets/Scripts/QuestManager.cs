using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor.VersionControl;

public class QuestManager : MonoBehaviour
{
	ArrayList monsterQuests = new ArrayList ();

	void Start ()
	{
		
	}

	void Update ()
	{
		
	}

	private MonsterQuest HasMonsterQuest (string monsterName)
	{
		foreach (MonsterQuest quest in monsterQuests) {
			if (quest.monsterName == monsterName) {
				return quest;
			}
		}
		return null;
	}

	public void AddMonsterQuest (string name, int amount, int experience)
	{
		monsterQuests.Add (new MonsterQuest (name, amount, experience));
	}

	public void AddMonsterQuest (MonsterQuest quest)
	{
		monsterQuests.Add (quest);
	}

	public void UpdateMonsterQuest (string monsterName)
	{
		MonsterQuest quest = null;
		if ((quest = HasMonsterQuest (monsterName)) != null) {
			Debug.Log ("in");
			quest.amount -= 1;
			if (quest.amount <= 0) {
				//Quest complete
				GetComponent<SkillManager> ().IncreaseLevelExperience (quest.experience);
				monsterQuests.Remove (quest);
			}
		} 
	}
}
