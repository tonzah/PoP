using UnityEngine;
using System.Collections;

public class Leaf : Potion {

	
	public Leaf(){

		this.ele = Element.Healing;
		this.icon = (Texture2D) Resources.Load("CraftingAssets/lehti.png");
		this.description = "Leaf increases heal by 10";
	}
	
	public override void Apply (SuperPotion spotion)
	{
		spotion.heal += 10;
	}
}
