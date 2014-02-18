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
		spotion.setPotions (plista);
		spotion.createPotion ();
	}
	
	// Update is called once per frame
	void Update () {
	
		string txt = spotion.dmg.ToString ();

		Debug.Log (txt + spotion.ele.ToString() + spotion.heal);
	}
}
