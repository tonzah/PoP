using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public int resource = 100;
	List<Potion> plista = new List<Potion>();
	List<GameObject> enemyBarracks = new List<GameObject>();
	float spawnSpeed = 4.0f;
	float spawnDelay = 0.0f;
	SuperPotion spotion = new SuperPotion ();
	SuperPotion rdypotion = new SuperPotion();

	// Use this for initialization
	void Start () {

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("EnemyBarrack")){

			enemyBarracks.Add(go);
		}


		plista.Add(new Firestone());
		plista.Add(new Firestone());
		plista.Add(new Firestone());
		plista.Add (new Leaf ());
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Time.time >= spawnDelay) {
			spawnDelay = Time.time + spawnSpeed;
			int random = Random.Range(0, enemyBarracks.Count);
			GameObject var = (GameObject)enemyBarracks[random];
			var.GetComponent<Barrack>().DeployEnemyUnit();
				}

		//string txt = spotion.dmg.ToString ();

		//Debug.Log (txt + spotion.ele.ToString() + spotion.heal);



	}

	void OnGUI() {

		 
		GUI.Label (new Rect (10, 10, 300, 100), "Sinulla on " + resource.ToString() + " resurssia");

		if(GUI.Button(new Rect(100,100, 100,100),"Valmista potion")){
			
			spotion.setPotions(plista);
			spotion.createPotion();
		}

	}



	}

