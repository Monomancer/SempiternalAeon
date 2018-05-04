using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;


public class DataController : MonoBehaviour {
    public static Player myPlayer;
    public static DataController controller;


	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
        controller = this;

        //NewPlayer();

        //call this from the menu but leave it here for now for testing purposes
        if (!PlayerPrefs.HasKey("playerInit"))
        {
            NewPlayer();
        }
        

        myPlayer = new Player();




        // we can modify this later to allow us to have a menu scene
       // SceneManager.LoadScene("townscene");

		
	}



    public Player getPlayer()
    {
        return myPlayer;
    }

    public void NewPlayer()
    {
        //remove any previously stored playerprefs
        PlayerPrefs.DeleteAll();
        //create new PlayerPrefs
        
        // BASIC PLAYER STATS
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.SetFloat("exp", 0);
        PlayerPrefs.SetInt("currentHealth", 100);
        PlayerPrefs.SetInt("maxHealth", 100);
        PlayerPrefs.SetInt("damage", 100);


        // PROGRESS STATS
        PlayerPrefs.SetInt("batsKilled", 0);
        PlayerPrefs.SetString("questType", "false");
        PlayerPrefs.SetInt("questsCompleted", 0);
        PlayerPrefs.SetInt("questProgress", 0);

        PlayerPrefs.SetInt("playerInit", 1);
    }

}
