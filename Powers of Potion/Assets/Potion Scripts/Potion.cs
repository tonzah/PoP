using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Potion : MonoBehaviour {

	public int current_stack;
	public int dmg;
	public int heal;
	public abstract void Apply(SuperPotion spotion); 
	public Element ele;
	

}
