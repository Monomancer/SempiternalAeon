using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawnManager : MonoBehaviour
{
	public int spawnCount;
	public int maxSpawns;
	public int spawnTime;
	private Boolean canSpawn;
	public GameObject enemy;
	private GameObject[] spawnPoints;
	// Use this for initialization
	void Start ()
	{
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		spawnCount = 0;
		canSpawn = true;
		if (spawnCount < maxSpawns) {
			Spawn (); 
		}
	}

	void Spawn ()
	{
		StartCoroutine (SpawnAfterDelay ());
	}

	IEnumerator SpawnAfterDelay ()
	{
		yield return new WaitForSeconds (spawnTime);
		if (spawnCount < maxSpawns) {
			int spawnPointIndex = UnityEngine.Random.Range (0, spawnPoints.Length); 
			Instantiate (enemy, spawnPoints [spawnPointIndex].transform.position, Quaternion.identity);
			spawnCount++;
			if (spawnCount < maxSpawns) {
				Spawn ();
			}
		}
	}

	public void ReduceSpawnCoint ()
	{
		spawnCount--;
		Spawn ();
	}

	public void SetEnemy (GameObject e)
	{
		enemy = e;
	}
}
