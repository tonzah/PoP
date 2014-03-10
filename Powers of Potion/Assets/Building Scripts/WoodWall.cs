using UnityEngine;
using System.Collections;

public class WoodWall : Building
{

		public WoodWall ()
		{

				this.hp = 100;
				this.hp_max = 100;
		}

		public override void applyUnitDmg(int dmg)
		{
	
		this.hp -= dmg;
			isDestroyed ();
		}

	public override void applyPotionDmg (SuperPotion spotion)
	{
		
		if (spotion.ele == Element.Fire) {
			
			this.hp -= (spotion.dmg * 2);
			
			
		} else {
			this.hp -= spotion.dmg;
			
		}
		isDestroyed ();
	}

}
