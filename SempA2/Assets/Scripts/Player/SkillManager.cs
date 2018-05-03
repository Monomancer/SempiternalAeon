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
        UpdateAmountToNextLevel();
	}

	// Update is called once per frame

	public void IncreaseLevelExperience (int amount)
	{
        DataController.myPlayer.Exp += amount;
		experience += amount;
		if (DataController.myPlayer.Exp >= amountToNextLevel) {
			LevelUp ();
		}

	}

	public void LevelUp ()
	{
		DataController.myPlayer.Level++;
        UpdateAmountToNextLevel();
        DataController.myPlayer.Exp = 0;
		uiManager.GetComponent<UIManager> ().ShowLevelText ();
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag ("Weapon")) {
			obj.GetComponent<DamageEnemy> ().damage += 1;
		}
        DataController.myPlayer.MaxHealth += 10;
        //gameObject.GetComponent<PlayerHealthManager> ().playerMaxHealth += 10;
        gameObject.GetComponent<PlayerHealthManager> ().SetMaxHealth ();
    }

    private void UpdateAmountToNextLevel()
    {
        amountToNextLevel = DataController.myPlayer.Level * 50 + (DataController.myPlayer.Level * 100 * 0.1f);
    }
}
