using UnityEngine;
using System.Collections;

public class Leaf : Potion {

	
	public Leaf(){
		
		this.ele = Element.Healing;
	}
	
	public override void Apply (SuperPotion spotion)
	{
		spotion.heal += 10;
	}
}
