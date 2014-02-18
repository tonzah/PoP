using UnityEngine;
using System.Collections;

public abstract class Building : MonoBehaviour
{

		public int hp;
		public int hp_max;
	public abstract void applyUnitDmg(int dmg);
	public abstract void applyPotionDmg(SuperPotion spotion);


}
