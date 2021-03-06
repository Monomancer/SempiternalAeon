﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding.Util;

public class EnemyHealthManager : MonoBehaviour
{

	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	public int experience;
	public GameObject[] loot;
	public GameObject combatText;
	private Animator anim;
	private SpriteRenderer spriteRend;
	private bool isDead;


	void Start ()
	{
		SetMaxHealth ();
		anim = GetComponent <Animator> ();
		spriteRend = gameObject.GetComponent<SpriteRenderer> ();
		isDead = false;
	}

	public void TakeDamage (int damage)
	{
		if (anim.GetBool ("isDead")) {
			return;
		}
		enemyCurrentHealth -= damage;
		var clone = (GameObject)Instantiate (combatText);
		clone.transform.position = gameObject.transform.position;
		clone.GetComponent<FloatingNumbers> ().damageNumber = damage;
		HitColorChange ();
		if (enemyCurrentHealth <= 0 && !isDead) {
			Die ();
		}
	}

	public void HitColorChange ()
	{
		Color col = spriteRend.color;
		StartCoroutine (ReturnOriginalColors (col));
		col.b -= 90;
		col.g -= 90;
		spriteRend.color = col;
	}

	IEnumerator ReturnOriginalColors (Color color)
	{
		yield return new WaitForSeconds (0.3f); 
		spriteRend.color = color;
	}

	void SetMaxHealth ()
	{
		enemyCurrentHealth = enemyMaxHealth;
	}

	void Die ()
	{
		isDead = true;
		anim.SetBool ("attack", false);
		anim.SetBool ("isDead", true);
		anim.Play ("die");
		SpawnLoot ();
		GrantExperience ();
		//GameObject.FindGameObjectWithTag ("UICanvas").GetComponent<PlayerStats> ().IncrementKills ();
		// GameObject.FindGameObjectWithTag ("Player").GetComponent<QuestManager> ().UpdateMonsterQuest (gameObject.GetComponent<MonsterAI> ().monsterName);
		gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
		if (gameObject.GetComponent<MonsterAI> ().monsterName == "BatMonster") {
			DataController.myPlayer.BatsKilled++;
		}
		GameObject.FindGameObjectWithTag ("SpawnManager").GetComponent<EnemySpawnManager> ().ReduceSpawnCount ();
		Destroy (gameObject, 1f);
	}

	void SpawnLoot ()
	{
		float lootPosOffset = 0f;
		foreach (GameObject drop in loot) {
			Transform pos = gameObject.transform;
			pos.position.Set (pos.position.x + lootPosOffset, pos.position.y, pos.position.z);
			Instantiate (drop, pos.position, Quaternion.identity);
			lootPosOffset += 0.1f;
		}
	}

	void GrantExperience ()
	{
		GameObject.FindGameObjectWithTag ("Player").GetComponent<SkillManager> ().IncreaseLevelExperience (experience);	
	}
}