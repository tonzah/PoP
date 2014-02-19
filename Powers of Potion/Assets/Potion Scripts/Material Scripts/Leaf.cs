using UnityEngine;
using System.Collections;

public class Leaf : Potion {

	
	public Leaf(){

		this.ele = Element.Healing;
<<<<<<< HEAD
		this.icon = (Texture2D) Resources.Load("CraftingAssets/lehti.png");
=======
		this.icon = (Texture2D) Resources.Load("Kuvat/action-icon-2.png");
>>>>>>> mpo
		this.description = "Leaf increases heal by 10";
	}
	
	public override void Apply (SuperPotion spotion)
	{
		spotion.heal += 10;
	}
}
