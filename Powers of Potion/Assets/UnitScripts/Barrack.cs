using UnityEngine;
using System.Collections;

public class Barrack : MonoBehaviour {

	public GameObject unit;
	public RaycastHit hit;
	GameObject clone;
	Vector3 location;

	// Use this for initialization
			void Start ()
		{

				if (this.transform.tag == "Player") {
						clone = (GameObject)Instantiate (unit, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 3), Quaternion.identity);
						clone.transform.tag = this.transform.tag;
		}
				if (this.transform.tag == "Enemy") {
						clone = (GameObject)Instantiate (unit, new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 3), Quaternion.identity);
						clone.transform.tag = this.transform.tag;
				}
		}
	
	// Update is called once per frame
	void Update () {



	

		//clone.transform.tag = this.transform.tag;
		
			
		
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
