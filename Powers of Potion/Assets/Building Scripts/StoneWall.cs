using UnityEngine;
using System.Collections;

public class StoneWall : Building
{
	
	public StoneWall ()
	{
		
		this.hp = 150;
		this.hp_max = 150;
	}
	
	public override void applyUnitDmg(int dmg)
	{
		
		this.hp -= (dmg - 5);
		isDestroyed ();
	}

	
	public override void applyPotionDmg (SuperPotion spotion)
	{
		
		if (spotion.ele == Element.Corrosive) {
			
			this.hp -= (spotion.dmg * 2);
			
			
		} else {
			this.hp -= spotion.dmg;
			
		}
		isDestroyed ();
	}
	
}