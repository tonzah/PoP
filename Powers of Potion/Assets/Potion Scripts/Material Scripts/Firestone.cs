using UnityEngine;
using System.Collections;

public class Firestone : Potion {



	public Firestone(){

		this.ele = Element.Fire;
		}

	public override void Apply (SuperPotion spotion)
	{
		spotion.dmg += 10;
	}

}
