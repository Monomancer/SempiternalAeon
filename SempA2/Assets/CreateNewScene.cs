using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateNewScene : MonoBehaviour {

    // Use this for initialization
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Grassy Scene", LoadSceneMode.Single);
        
        
    }

}
	


