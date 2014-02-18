using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SuperPotion : Potion {


	private List<Potion> potions;
	
	public SuperPotion(){

		this.dmg = 0;
		this.heal = 0;

		}


	public void setPotions(List<Potion> potionsz){

		this.potions = potionsz;
	}


	public void createPotion(){
	
		foreach (Potion p in potions) {
			p.Apply(this);		
		}

		setElement (potions[0].ele);

		}

	public void setElement(Element ele){

		this.ele = ele;

		}


	public override void Apply(SuperPotion spotion)
	{

	}
}
