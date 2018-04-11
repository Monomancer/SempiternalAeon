using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

	public int level = 1;
	public int experience = 0;
	public GameObject uiManager;

	// Use this for initialization
	void Start ()
	{
		
	}

	// Update is called once per frame
	void Update ()
	{
		
	}

	public void IncreaseLevelExperience (int amount)
	{
		experience += amount;
		if (experience >= level * 100 + (level * 100 * 0.2f)) {
			LevelUp ();
		}
	}

	public void LevelUp ()
	{
		uiManager.GetComponent<UIManager> ().ShowLevelText ();
		level++;
		gameObject.GetComponentInChildren<EdgeCollider2D> ().GetComponent<DamageEnemy> ().damage += 1;
		gameObject.GetComponent<PlayerHealthManager> ().playerMaxHealth += 10;
		gameObject.GetComponent<PlayerHealthManager> ().SetMaxHealth ();
	}
}
