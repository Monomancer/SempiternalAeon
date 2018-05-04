using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemySpawnManager : MonoBehaviour
{
	public int maxSpawns;
	public int spawnTime;
	public GameObject[] enemies;
	private Camera playerCam;
	private int spawnCount;
	private GameObject[] spawnPoints;
	// Use this for initialization
	void Start ()
	{
		playerCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		spawnCount = 0;
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		if (spawnPoints.Length == 0) {
			Debug.Log ("No spawn points found!");
			StartCoroutine (CheckForSpawns ());
			return;
		}
		if (spawnCount < maxSpawns) {
			Spawn (); 
		}
	}

	public void Spawn ()
	{
		StartCoroutine (SpawnAfterDelay ());
	}

	private IEnumerator SpawnAfterDelay ()
	{


		yield return new WaitForSeconds (spawnTime);
		if (spawnCount < maxSpawns) {
			Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
			int spawnPointIndex = UnityEngine.Random.Range (0, spawnPoints.Length); 

			if (playerCam == null) {
				Debug.Log ("Players camera not found!");
			} else {
				// Ensures enemies do not spawn on players exact location
				// and are not in cameras view
				while (spawnPoints.Length > 1 && (spawnPoints [spawnPointIndex].transform.position == player.position || InCamerasView (spawnPoints [spawnPointIndex].transform))) {
					spawnPointIndex = UnityEngine.Random.Range (0, spawnPoints.Length); 	
				}
			}
			if (enemies.Length > 0) {
				Instantiate (enemies [UnityEngine.Random.Range (0, enemies.Length)], spawnPoints [spawnPointIndex].transform.position, Quaternion.identity);
			} else {
				Debug.Log ("No enemies found!");
			}

			spawnCount++;
			if (spawnCount < maxSpawns) {
				Spawn ();
			}
		}
	}

	private IEnumerator CheckForSpawns ()
	{
		yield return new WaitForSeconds (3);
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		if (spawnPoints.Length == 0) {
			Debug.Log ("No spawn points found!");
			StartCoroutine (CheckForSpawns ());
		} else {
			Spawn ();
		}
	}

	private Boolean InCamerasView (Transform t)
	{
		Vector3 viewPos = playerCam.WorldToViewportPoint (t.position);
		if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z > 0) {
			return true;
		} else {
			return false;
		}
	}

	public void ReduceSpawnCount ()
	{
		spawnCount--;
		Spawn ();
	}

	public void SetEnemy (GameObject e)
	{

	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemySpawnManager : MonoBehaviour
{
	public int maxSpawns;
	public int spawnTime;
	public GameObject enemy;
    public GameObject enemy2;
	private Camera playerCam;
	private int spawnCount;
	private GameObject[] spawnPoints;
    private float r; 
    // Use this for initialization
    void Start ()
	{
        r = UnityEngine.Random.Range(-10.0f, 10.0f);
        playerCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		spawnCount = 0;
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		if (spawnPoints.Length == 0) {
			Debug.Log ("No spawn points found!");
			StartCoroutine (CheckForSpawns ());
			return;
		}
		if (spawnCount < maxSpawns) {
			Spawn (); 
		}
	}

	public void Spawn ()
	{
		StartCoroutine (SpawnAfterDelay ());
	}

	private IEnumerator SpawnAfterDelay ()
	{
        

        yield return new WaitForSeconds (spawnTime);
		if (spawnCount < maxSpawns) {
			Transform player = GameObject.FindGameObjectWithTag ("Player").transform;
			int spawnPointIndex = UnityEngine.Random.Range (0, spawnPoints.Length); 

			if (playerCam == null) {
				Debug.Log ("Players camera not found!");
			} else {
				// Ensures enemies do not spawn on players exact location
				// and are not in cameras view
				while (spawnPoints.Length > 1 && (spawnPoints [spawnPointIndex].transform.position == player.position || InCamerasView (spawnPoints [spawnPointIndex].transform))) {
					spawnPointIndex = UnityEngine.Random.Range (0, spawnPoints.Length); 	
				}
			}
            if (UnityEngine.Random.Range(-10.0f, 10.0f) > .5)
            {
                Instantiate(enemy, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            }
            else {
                Instantiate(enemy2, spawnPoints[spawnPointIndex].transform.position, Quaternion.identity);
            }
			
			spawnCount++;
			if (spawnCount < maxSpawns) {
				Spawn ();
			}
		}
	}

	private IEnumerator CheckForSpawns ()
	{
		yield return new WaitForSeconds (3);
		spawnPoints = GameObject.FindGameObjectsWithTag ("SpawnPoint");
		if (spawnPoints.Length == 0) {
			Debug.Log ("No spawn points found!");
			StartCoroutine (CheckForSpawns ());
		} else {
			Spawn ();
		}
	}

	private Boolean InCamerasView (Transform t)
	{
		Vector3 viewPos = playerCam.WorldToViewportPoint (t.position);
		if (viewPos.x > 0 && viewPos.x < 1 && viewPos.y > 0 && viewPos.y < 1 && viewPos.z > 0) {
			return true;
		} else {
			return false;
		}
	}

	public void ReduceSpawnCount ()
	{
		spawnCount--;
		Spawn ();
	}

	public void SetEnemy (GameObject e)
	{
		enemy = e;
	}
}
