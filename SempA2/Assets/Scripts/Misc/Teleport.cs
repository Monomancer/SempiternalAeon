using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Teleport : MonoBehaviour
{
	public int HARD_CODED_CHANGE;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Player") {
			SceneManager.LoadScene ("TownScene", LoadSceneMode.Single);
		}
	}
}