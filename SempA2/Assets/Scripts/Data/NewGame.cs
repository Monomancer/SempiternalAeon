using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NewGame : MonoBehaviour {

    // Use this for initialization
    public void OnButtonClick()
    {
        Debug.Log("newGame script called");
        DataController.controller.NewPlayer();
        SceneManager.LoadScene("townscene");
    }
	

}
