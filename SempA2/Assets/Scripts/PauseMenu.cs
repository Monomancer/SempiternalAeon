using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

	public bool isPaused;

	public GameObject pauseMenuCanvas;
	public GameObject uiManager;

	void Update ()
	{
		if (isPaused) {
			
			Time.timeScale = 0;
			pauseMenuCanvas.SetActive (true);
			uiManager.GetComponent<UIManager> ().CloseAllUI ();
		} else {
			Time.timeScale = 1;
			pauseMenuCanvas.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			isPaused = !isPaused;			
		}
	}

	public void Resume ()
	{
		Debug.Log ("Clicked");
		Time.timeScale = 1;
		isPaused = false;
	}

	public void Quit ()
	{
		Application.Quit ();	
	}
}
