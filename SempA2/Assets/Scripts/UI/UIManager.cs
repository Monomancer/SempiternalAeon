using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Runtime.Remoting;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

	public Slider healthBar;
	public Text healthText;
	//private PlayerHealthManager ph = null;
	public GameObject tabMenu;
	public GameObject levelUpText;
	public Boolean inMenu = false;

	private static bool UIExists;

	// Use this for initialization
	void Start ()
	{
		if (SceneManager.GetActiveScene ().name == "Platform generation") {
			//ph = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealthManager> ();
		}
		if (!UIExists) {
			UIExists = true;

			// For whatever reason these cause UI elements to be deleted when reloading
			// scene rather than persisting
			//DontDestroyOnLoad (transform.gameObject);
		} else {
			//Destroy (gameObject); 
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

			healthBar.maxValue = DataController.myPlayer.MaxHealth;
			healthBar.value = DataController.myPlayer.CurrentHealth;
			healthText.text = "HP: " + DataController.myPlayer.CurrentHealth + "/" + DataController.myPlayer.MaxHealth;

			Debug.Log ("Player does not exist, cannot update health UI");
		

		if (inMenu) {
			tabMenu.SetActive (true);
		} else {
			tabMenu.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Tab)) {
			inMenu = !inMenu;		
		}
	}

	public void CloseAllUI ()
	{
		inMenu = false;
		tabMenu.SetActive (false);


	}

	public void ShowLevelText ()
	{
		levelUpText.SetActive (true);
		StartCoroutine (RemoveAfterSeconds (5, levelUpText));

	}

	IEnumerator RemoveAfterSeconds (int seconds, GameObject obj)
	{
		yield return new WaitForSeconds (seconds);
		obj.SetActive (false);
	}
}
