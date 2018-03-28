using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

	public bool isPaused;

	public GameObject pauseMenuCanvas;

	void Update ()
	{
		if (isPaused) {
			Time.timeScale = 0;
			pauseMenuCanvas.SetActive (true);
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
		Time.timeScale = 1;
		isPaused = false;
	}

	public void Quit ()
	{
		Application.Quit ();	
	}
}
