using UnityEngine;
using System.Collections;

public class Firestone : Potion {


	public Firestone(){
		this.isEquipment = true;
		this.ele = Element.Fire;
		this.icon = (Texture2D) Resources.Load("CraftingAssets/tuli.png");
		this.description = "Firestone increases damage by 10";
		}

	void Start(){

		Vector3 v = transform.position;
		this.orig_position = v;
		}


	public override void Apply (SuperPotion spotion)
	{
		spotion.dmg += 10;
	}


}
