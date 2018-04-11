using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{

	public int enemyMaxHealth;
	public int enemyCurrentHealth;
	public int experience;
	public GameObject[] loot;
	public GameObject combatText;
	private Animator anim;

	void Start ()
	{
		SetMaxHealth ();
		anim = GetComponent <Animator> ();

	}

	void Update ()
	{
	}

	public void TakeDamage (int damage)
	{
		enemyCurrentHealth -= damage;
		var clone = (GameObject)Instantiate (combatText);
		clone.transform.position = gameObject.transform.position;
		clone.GetComponent<FloatingNumbers> ().damageNumber = damage;
		if (enemyCurrentHealth <= 0) {
			Die ();
		}
	}

	void SetMaxHealth ()
	{
		enemyCurrentHealth = enemyMaxHealth;
	}

	void Die ()
	{
		anim.SetBool ("attack", false);
		anim.Play ("die");
		SpawnLoot ();
		GrantExperience ();
		gameObject.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
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
		
		
	}
}