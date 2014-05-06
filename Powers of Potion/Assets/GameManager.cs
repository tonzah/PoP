using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	public int resource = 100;

	public static int playercastle = 100;
	public static int enemycastle = 100;


	CraftManager craftManager; // ref to craftmanager

	List<GameObject> potionObj = new List<GameObject> ();

	List<GameObject> enemyBarracks = new List<GameObject>();
	float spawnSpeed = 4.0f;
	float spawnDelay = 0.0f;

	bool isGinit = false;
	

	public GameObject fireobj;			//firestoneprefab



	// Use this for initialization
	void Start () {

		craftManager = (CraftManager)gameObject.GetComponent (typeof(CraftManager));

		foreach(GameObject go in GameObject.FindGameObjectsWithTag("EnemyBarrack")){

			enemyBarracks.Add(go);
		}

		float offset = 0.1f;

		for(int i = 0; i < 3; i++)
		{

			GameObject clone = (GameObject)Instantiate(fireobj, new Vector3(offset,0.1f,0.0f), transform.rotation);
			potionObj.Add(clone);

			offset += 0.1f;
		}


		craftManager.AddItem (fireobj);
		craftManager.AddItem (fireobj);
		craftManager.AddItem (fireobj);



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

	public  void DamagePlayerKeep()
	{
		playercastle -= 2;
		}
	public static void DamageEnemyKeep()
	{
		enemycastle -= 2;
	}



	void OnGUI() {

		 
		GUI.Label (new Rect (10, 10, 300, 100), "Sinulla on " + resource.ToString() + " resurssia");
		GUI.Label (new Rect (10, 30, 300, 100), "Vihollisen linnalla on " + enemycastle.ToString() + " kestävyyttä");


	}



	}

