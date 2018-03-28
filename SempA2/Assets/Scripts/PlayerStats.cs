using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public int currentLevel;
	public int currentExp;
	public int expModifier;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (currentLevel == currentLevel * expModifier) {
			
		}
	}
}
