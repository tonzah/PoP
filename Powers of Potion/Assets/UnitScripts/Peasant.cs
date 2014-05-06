using UnityEngine;
using System.Collections;

public class Peasant : Unit
{
	float attackDelay = 0.0f;

		public Peasant ()
		{

				this.hp = 10;
				this.damage = 1;
				this.atkSpeed = 1.0f;
				this.spotion = null;
				this.movementspeed = 5;
				this.inMove = true;
				this.inFight = false;
				this.inFighting = false;
				this.e_unit = null;

		}
	

		public override void AttackTarget (GameObject target)
		{
				Debug.Log ("attacking target");
				this.e_unit = (Unit)target.GetComponent (typeof(Unit));
				inFight = true;
				inFighting = true;
				inMove = false;
		
		}
	
		public override void ApplyUnitDmg (int dmg)
		{
				this.hp -= dmg;
				checkIfDead ();

		}

		public override void ApplyPotionDmg (SuperPotion spotion)
		{
				this.hp -= spotion.dmg;

		}

		public void checkEnemy ()
		{
	
				//	Vector3 frw = new Vector3 (this.transform.position.x + 5, 0, 0);
				RaycastHit hit;
				//	Ray r = new Ray (this.transform.position, transform.right);
				

				if (this.transform.tag == "Player") {
						//			Vector3 fwd = transform.TransformDirection (Vector3.right);
						Debug.DrawRay (this.transform.position, Vector3.right, Color.green, 2.0f);

						if (Physics.Raycast (transform.position, Vector3.right, out hit, 20.0f) && hit.transform.tag == "Enemy" || hit.transform.tag=="EnemyCastle") {
								if(hit.transform.tag=="Enemy"){
					AttackTarget (hit.transform.gameObject);
				}
				else
				{
					GameManager.DamageEnemyKeep();
					inFight = true;
					inFighting = true;
					inMove = false;
				}
						}
				} else if (this.transform.tag == "Enemy") {
	
						if (Physics.Raycast (transform.position, Vector3.left, out hit, 20.0f) && hit.transform.tag == "Player") {

								Debug.DrawRay (this.transform.position, Vector3.left, Color.red, 2.0f);
								AttackTarget (hit.transform.gameObject);
	
						}

				}

		}
		// Update is called once per frame
		void Update ()
		{
			if (e_unit == null) {
			inFighting = false;
			inFight = false;
			inMove = true;
				}
	

				if (inMove) {
						moveUnit ();
						checkEnemy ();
				}
				if (inFight) {
						//		Debug.Log (this.name + " löysi " + e_unit.name);

						Debug.Log ("eka");

						if (Time.time >= attackDelay) {
								Debug.Log ("toka");
								attackDelay = Time.time + atkSpeed;
								// Do damage here
								this.animation.Play ("attack");
									
				if(e_unit!=null)
			e_unit.ApplyUnitDmg (this.damage);

			}
							
				}
				//	inMove = true;
				//	e_unit = null;

		}


}
