using UnityEngine;
using System.Collections;

public class Firestone : Potion {



	public Firestone(){

		this.ele = Element.Fire;
		this.icon = (Texture2D) Resources.Load("CraftingAssets/tuli.png");
		this.description = "Firestone increases damage by 10";
		}

	public override void Apply (SuperPotion spotion)
	{
		spotion.dmg += 10;
	}

}
