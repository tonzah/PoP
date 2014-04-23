using UnityEngine;
using System.Collections;

public abstract class Unit : MonoBehaviour
{

	
		public int hp;
		public int movementspeed;
		public int movementdirection;
		public int damage;
		public float atkSpeed;
		public Peasant e_unit;


	public bool inFight;
	public bool inMove;
	public bool inFighting;


		public SuperPotion spotion;
		public abstract void AttackTarget (GameObject target);
		public abstract void ApplyUnitDmg (int dmg);
		public abstract void ApplyPotionDmg (SuperPotion spotion);


	
		public void setMovementDirection (int i)	// Left-side player 1, Enemy player -1
		{
				this.movementdirection = i;
		}

		public void moveUnit ()
		{
		if (inMove) {
			this.animation.Play("kavely");
						this.transform.Translate ((Time.deltaTime * (movementdirection * movementspeed)), 0, 0);
				}
		}


		public void givePotion (SuperPotion spotion)
		{
				this.spotion = spotion;
		}


}
