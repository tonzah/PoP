using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour {

	
	public int hp;
	public int movementspeed;
	public int movementdirection;
	public int damage;
	public SuperPotion spotion;
	public abstract void AttackUnit(Unit target);
	public abstract void AttackBuilding(Building target);
	public abstract void ApplyUnitDmg(int dmg);
	public abstract void ApplyPotionDmg(SuperPotion spotion);



	public void checkIfDead(){

		if(this.hp <= 0)
		{
			Destroy(this.gameObject);
		}

	}

	public void givePotion(SuperPotion spotion){
		this.spotion = spotion;
	}


}
