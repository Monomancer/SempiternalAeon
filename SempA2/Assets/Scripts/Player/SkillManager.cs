using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{

	//public int level = 1;
	public GameObject uiManager;
	//private float experience = 0;
	private float amountToNextLevel;

	// Use this for initialization
	void Start ()
	{
        UpdateAmount();
		
	}

	// Update is called once per frame
	void Update ()
	{
	}

	public void IncreaseLevelExperience (int amount)
	{
		DataController.myPlayer.Exp += amount;
		if (DataController.myPlayer.Exp >= amountToNextLevel) {
			LevelUp ();
		}

	}

	public void LevelUp ()
	{
		DataController.myPlayer.Level++;
        UpdateAmount();
        DataController.myPlayer.Exp = 0;
		uiManager.GetComponent<UIManager> ().ShowLevelText ();
        DataController.myPlayer.Damage += 1;
        Debug.Log("damage is now " + DataController.myPlayer.Damage);

		DataController.myPlayer.MaxHealth += 10;
		gameObject.GetComponent<PlayerHealthManager> ().SetMaxHealth ();
	}

    private void UpdateAmount()
    {

        amountToNextLevel = DataController.myPlayer.Level * 50 + (DataController.myPlayer.Level * 100 * 0.1f);
        Debug.Log("amount to next level" + amountToNextLevel);
    }
}
