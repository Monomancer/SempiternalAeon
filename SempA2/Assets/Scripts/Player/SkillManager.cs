using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

	public int level = 1;
	public GameObject uiManager;
	private float experience = 0;
	private float amountToNextLevel;

	// Use this for initialization
	void Start ()
	{
		amountToNextLevel = level * 50 + (level * 100 * 0.1f);
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public void IncreaseLevelExperience (int amount)
	{
		experience += amount;
		if (experience >= amountToNextLevel) {
			LevelUp ();
		}

	}

	public void LevelUp ()
	{
		level++;
		amountToNextLevel = level * 50 + (level * 100 * 0.1f);
		experience = 0;
		uiManager.GetComponent<UIManager> ().ShowLevelText ();
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Weapon")) {
			obj.GetComponent<DamageEnemy> ().damage += 1;
		}
		gameObject.GetComponent<PlayerHealthManager> ().playerMaxHealth += 10;
		gameObject.GetComponent<PlayerHealthManager> ().SetMaxHealth ();
	}
}
