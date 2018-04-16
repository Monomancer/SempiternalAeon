using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{

	public float moveSpeed;
	public int damageNumber;
	public Text displayText;

	// Use this for initialization
	void Start ()
	{	
	}
	
	// Update is called once per frame
	void Update ()
	{
		displayText.text = "" + damageNumber;
		transform.position = new Vector2 (transform.position.x, transform.position.y + (moveSpeed * Time.deltaTime));
	}

	public void setColor (Color color)
	{
		displayText.color = color;		
	}
}
