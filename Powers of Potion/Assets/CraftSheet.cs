using UnityEngine;
using System.Collections.Generic;

public class CraftSheet : MonoBehaviour
{


	GameObject[] slots = new GameObject[3];
	public SuperPotion spotion;
		
		//private var ArmorSlot : Item[]; //This is the built in Array that stores the Items equipped. You can change this to static if you want to access it from another script.
//	var ArmorSlotName : String[]; //This determines how many slots the character has (Head, Legs, Weapon and so on) and the text on each slot.
		List<Rect> buttonPositions = new List<Rect> (); //This list will contain where all buttons, equipped or not will be and SHOULD HAVE THE SAME NUMBER OF cells as the ArmorSlot array.
	
		Vector2 windowSize = new Vector2 (375, 300); //The size of the character window.
		bool useCustomPosition = true; //Do we want to use the customPosition variable to define where on the screen the Character window will appear.
		Vector2 customPosition = new Vector2 (70, 70); //The custom position of the Character window.
		GUISkin cSheetSkin; //This is where you can add a custom GUI skin or use the one included (CSheetSkin) under the Resources folder.
		bool canBeDragged = true; //Can the Character window be dragged?
	
		//var onOffButton : KeyCode = KeyCode.I; //The key to toggle the Character window on and of.
	
		//var DebugMode = false; //If this is enabled, debug.logs will print out information when something happens (equipping items etc.).
	
		static bool csheet = true; //Helps with turning the CharacterSheet on and off.
	
		private Rect windowRect = new Rect (100, 100, 200, 300); //Keeping track of our character window.

		Vector2 offset = new Vector2 (7, 12); 
	Vector2 itemIconSize  = new Vector2(60.0f, 60.0f);
	
		//These are keeping track of components such as equipmentEffects and Audio.

		private CraftManager craftinv;	//Refers to the CraftManager script.

//	private var equipmentEffectIs = false;
//	private var invAudio : InvAudio;
//	private var invDispKeyIsSame = false;

		

		//Assign the differnet components to variables and other "behind the scenes" stuff.
		void Awake ()
		{
				craftinv = (CraftManager)this.gameObject.GetComponent (typeof(CraftManager));
		
				if (useCustomPosition == false) {
						windowRect = new Rect (Screen.width - windowSize.x - 70, Screen.height - windowSize.y - (162.5f + 70.0f * 2.0f), windowSize.x, windowSize.y);
				} else {
						windowRect = new Rect (customPosition.x, customPosition.y, windowSize.x, windowSize.y);
				}

		}




		//Checking if we already have somthing equipped
		public bool CheckSlot (int tocheck)
		{
				bool toreturn = false;
				if (slots [tocheck] != null) {
						toreturn = true;
				}
				return toreturn;
		}
	
		//Using the item. If we assign a slot, we already know where to equip it.

	
		//Equip an item to a slot.
		public void EquipItem (GameObject i, int slot)
		{
				if (CheckSlot (slot)) { //If theres an item equipped to that slot we unequip it first:
						UnequipItem (slots [slot]);
						slots [slot] = null;
				}
				slots [slot] = i; //When we find the slot we set it to the item.
				craftinv.RemoveItem (i); //We remove the item from the inventory		
		}
	
		//Unequip an item.
		public void UnequipItem (GameObject i)
		{
				
				craftinv.AddItem (i);
		}
	


	
		//Draw the Character Window
		void OnGUI ()
		{
				GUI.skin = cSheetSkin; //Use the cSheetSkin variable.
		
				if (csheet) { //If the csheet is opened up.
						//Make a window that shows what's in the csheet called "Character" and update the position and size variables from the window variables.

						windowRect = GUI.Window (1, windowRect, DisplayCSheetWindow, "CraftTable");

			if(GUI.Button(new Rect(windowRect.x*0.5f,windowRect.y,50,50),"Valmista potion")){

				if(slots.Length == 3 && slots!= null)
				{
					List<Potion> potionz = new List<Potion>();

					foreach(GameObject a in slots)
					{
						Potion p = (Potion)a.GetComponent(typeof(Potion));
						potionz.Add(p);
					}
					spotion.setPotions(potionz);
					spotion.createPotion();
					Debug.Log("Parantaa " + spotion.heal.ToString() + " tekee damagea " + spotion.dmg.ToString());
				}
				else
				{
					Debug.Log("Tarvitset kaikki materiaalit");
				}

			}
				}
		}
	
		//This will display the character sheet and handle the buttons.
		public void DisplayCSheetWindow (int windowID)
		{

				if (canBeDragged == true) {
						GUI.DragWindow (new Rect (0, 0, 10000, 30));  //The window is dragable.
				}



		var currentX = 0 + offset.x; //Where to put the first items.
		var currentY = 18 + offset.y; //Im setting the start y position to 18 to give room for the title bar on the window.
		
				int index = 0;


		foreach (GameObject a in slots) { //Loop through the ArmorSlot array.
						Debug.Log ("MOIKKELISMOI");

						if (a == null) {

								Debug.Log ("YOYOYO");

				if (GUI.Button (new Rect(currentX,currentY,itemIconSize.x,itemIconSize.y), "Laita Potionit tänne")) { //If we click this button (that has no item equipped):
										CraftTableDisplay id = (CraftTableDisplay)this.gameObject.GetComponent (typeof(CraftTableDisplay));
										if (id.itemBeingDragged != null) { //If we are dragging an item:
												EquipItem (id.itemBeingDragged, index); //Equip the Item.
												id.ClearDraggedItem ();//Stop dragging the item.
										}
								}
						} else {
				if (GUI.Button (new Rect(currentX,currentY,itemIconSize.x,itemIconSize.y), ((Potion)slots [index].GetComponent (typeof(Potion))).icon)) { //If we click this button (that has an item equipped):
										CraftTableDisplay id2 = (CraftTableDisplay)this.gameObject.GetComponent (typeof(CraftTableDisplay));
										if (id2.itemBeingDragged != null) { //If we are dragging an item:
												EquipItem (id2.itemBeingDragged, index); //Equip the Item.
												id2.ClearDraggedItem (); //Stop dragging the item.
										} else if (craftinv.content.Count < craftinv.MaxContent) { //If there is room in the inventory:
												UnequipItem (slots [index]); //Unequip the Item.
												slots [index] = null; //Clear the slot.
												id2.ClearDraggedItem (); //Stop dragging the Item.
										}

								}
						}
						index++;
			currentX += itemIconSize.x;
			if(currentX + itemIconSize.x + offset.x > windowSize.x) //Make new row
			{
				currentX=offset.x; //Move it back to its startpoint wich is 0 + offsetX.
				currentY+=itemIconSize.y; //Move it down a row.
				if(currentY + itemIconSize.y + offset.y > windowSize.y) //If there are no more room for rows we exit the loop.
				{
					return;
				}
			}
				}
		}



}
