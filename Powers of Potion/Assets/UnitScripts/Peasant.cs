using UnityEngine;
using System.Collections;

public class Peasant : Unit {
	



	public Peasant(){

		this.hp = 10;
		this.damage = 10;
		this.spotion = null;
		this.movementspeed = 5;
	}

	
	// Use this for initialization
	void Start () {
		
		if (this.transform.tag == "Player")
		{
			movementdirection = 1;
		}
		if (this.transform.tag == "Enemy")
			movementdirection = -1;
	}

	public override void AttackUnit (Unit target)
	{
		throw new System.NotImplementedException ();
	}

	public override void AttackBuilding (Building target)
	{
		throw new System.NotImplementedException ();
	}

	public override void ApplyUnitDmg (int dmg)
	{
		this.hp -= dmg;
		checkIfDead();

	}
	public override void ApplyPotionDmg (SuperPotion spotion)
	{
		this.hp -= spotion.dmg;
		checkIfDead();
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate( (Time.deltaTime * movementdirection), 0, 0);
		
	}
	

}
