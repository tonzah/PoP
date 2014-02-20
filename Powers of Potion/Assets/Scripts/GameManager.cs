using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {


	List<Potion> plista = new List<Potion>();
	SuperPotion spotion = new SuperPotion ();
	SuperPotion rdypotion = new SuperPotion();

	// Use this for initialization
	void Start () {

		plista.Add(new Firestone());
		plista.Add(new Firestone());
		plista.Add(new Firestone());
		plista.Add (new Leaf ());
	}
	
	// Update is called once per frame
	void Update () {
	
		//string txt = spotion.dmg.ToString ();

		//Debug.Log (txt + spotion.ele.ToString() + spotion.heal);


		if (Input.touchCount == 1) {
			// Do something
		}




	}

	void OnGUI() {

		if(GUI.Button(new Rect(100,100, 100,100),"Valmista potion")){
			
			spotion.setPotions(plista);
			spotion.createPotion();
		}


	}

}
