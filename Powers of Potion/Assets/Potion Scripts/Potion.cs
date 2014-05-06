using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Potion : MonoBehaviour {

	public int current_stack;
	public int dmg;
	public int heal;
	public abstract void Apply(SuperPotion spotion); 
	public Element ele;
	public Texture2D icon;
	public string description;
	public bool isEquipment;


	//Potion GUITtexture variables

	public Vector3 orig_position;

}
