﻿using UnityEngine;
using System.Collections;

public class Barrack : MonoBehaviour {

	public GameObject unit;
	public GameObject enemyUnit;
	public RaycastHit hit;
	Vector3 location;
	GameObject clone;

		
	void Update()
	{



		// If platform is mobile
		if (Input.touchCount == 1)
		{
			Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);


			Vector2 touchPos = new Vector2(wp.x, wp.y);


			if (collider2D == Physics2D.OverlapPoint(touchPos))
			{
						

				if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit) && hit.transform.tag == "PlayerBarrack") {
					clone = (GameObject)Instantiate (unit, new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 3), Quaternion.identity);
					clone.transform.tag = "Player";
					((Unit)clone.GetComponent(typeof(Unit))).setMovementDirection(1);
					 

				}
			}



			// If platform is PC
		}
		else if (Input.GetMouseButton(0)){

			Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 mousePos = new Vector2(mp.x,mp.y);
			
			if(Input.GetMouseButton(0))
			{
			
				
				if (collider2D == Physics2D.OverlapPoint(mousePos))
				{

					if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.transform.tag == "PlayerBarrack") {
						clone = (GameObject)Instantiate (unit, new Vector3 (hit.transform.position.x, hit.transform.position.y, hit.transform.position.z - 3), Quaternion.identity);
						clone.transform.tag = "Player";
						((Unit)clone.GetComponent(typeof(Unit))).setMovementDirection(1);
					}
				}
				
				
				
			}

		}

	}

	public void DeployEnemyUnit(){

		clone = (GameObject)Instantiate (enemyUnit, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 3), Quaternion.identity);
		clone.transform.tag = "Enemy";
		clone.transform.localScale = new Vector3(-10,10,1);
		((Unit)clone.GetComponent(typeof(Unit))).setMovementDirection(-1);

	}
	
	/*
	public GameObject unit;
	public GameObject clone;
	clone = (GameObject)Instantiate (unit, new Vector2(-0.5f, 0), Quaternion.identity);



	void OnMouseDown()
	{	
		if(this.transform.tag == "Player")
		clone = (GameObject)Instantiate (unit, new Vector2(-0.5f, 0), Quaternion.identity);
		Debug.Log("barracks clicked");	
	}
*/
}
