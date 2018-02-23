using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport1 : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.position = new Vector3 (12, 0, 0);
		}
	}
}
