using UnityEngine;
using System.Collections.Generic;

public class CraftTableDisplay : MonoBehaviour {

	List<GameObject> UpdatedList = new List<GameObject>();  //The updated inventory array.
	CraftManager associatedInventory;


	public GameObject itemBeingDragged; //This refers to the potion
	private Vector2 draggedItemPosition; //Where on the screen we are dragging our Item.
	private Vector2 draggedItemSize;	//The size of the item icon we are dragging.
	
	//Variables for the window:
	Vector2 windowSize = new Vector2(375.0f, 100); //The size of the Inventory window.
	bool useCustomPosition = false; //Do we want to use the customPosition variable to define where on the screen the Inventory window will appear?
	Vector2 customPosition = new Vector2 (70, 400); // The custom position of the Inventory window.
	Vector2 itemIconSize  = new Vector2(60.0f, 60.0f); //The size of the item icons.
	
	//Variables for updating the inventory
	float updateListDelay = 9999;//This can be used to update the Inventory with a certain delay rather than updating it every time the OnGUI is called.
	//This is only useful if you are expanding on the Inventory System cause by default Inventory has a system for only updating when needed (when an item is added or removed).
	private float lastUpdate = 0.0f; //Last time we updated the display.
	
	//More variables for the window:

	private Rect windowRect = new Rect (200,200,108,130); //Keeping track of the Inventory window.
	GUISkin invSkin; //This is where you can add a custom GUI skin or use the one included (InventorySkin) under the Resources folder.
	Vector2 offset = new Vector2 (7, 12); //This will leave so many pixels between the edge of the window (x = horizontal and y = vertical).
	bool canBeDragged = true; //Can the Inventory window be dragged?
	


	// Use this for initialization
	void Awake () {
		associatedInventory = (CraftManager)this.gameObject.GetComponent(typeof(CraftManager));

		if (useCustomPosition == false)
		{
			windowRect=new Rect(Screen.width-windowSize.x-70,Screen.height-windowSize.y-70,windowSize.x,windowSize.y);
		}


	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.Escape)) //Pressed escape
		{
			ClearDraggedItem(); //Get rid of the dragged item.
		}
		if(Input.GetMouseButtonDown(1)) //Pressed right mouse
		{
			ClearDraggedItem(); //Get rid of the dragged item.
		}
		
		//Always show Inventory

		
		
		//Making the dragged icon update its position
		if(itemBeingDragged!=null)
		{
			//Give it a 15 pixel space from the mouse pointer to allow the Player to click stuff and not hit the button we are dragging.
			draggedItemPosition.y=Screen.height-Input.mousePosition.y+15;
			draggedItemPosition.x=Input.mousePosition.x+15;
		}
		
		//Updating the list by delay
		if(Time.time>lastUpdate){
			lastUpdate=Time.time+updateListDelay;
			UpdateInventoryList();
		}
	}

	//Drawing the Inventory window
	void OnGUI()
	{
		GUI.skin = invSkin; //Use the invSkin
		if(itemBeingDragged != null) //If we are dragging an Item, draw the button on top:
		{
			GUI.depth = 3;
			GUI.Button(new Rect(draggedItemPosition.x,draggedItemPosition.y,draggedItemSize.x,draggedItemSize.y),((Potion)itemBeingDragged.GetComponent(typeof(Potion))).icon);
			GUI.depth = 0;
		}

			windowRect = GUI.Window (0, windowRect, DisplayInventoryWindow, "Inventory");

	}

	public void DisplayInventoryWindow(int windowID)
	{
		
		if (canBeDragged == true)
		{
			GUI.DragWindow (new Rect (0,0, 10000, 30));  //the window to be able to be dragged
		}
		
		var currentX = 0 + offset.x; //Where to put the first items.
		var currentY = 18 + offset.y; //Im setting the start y position to 18 to give room for the title bar on the window.
		
		foreach(GameObject i in UpdatedList) //Start a loop for whats in our list.
		{

			GameObject item= i;
			Potion p = (Potion)i.GetComponent(typeof(Potion)); //lyhyempi versio

				if(GUI.Button(new Rect(currentX,currentY,itemIconSize.x,itemIconSize.y),p.icon))
				{
					bool dragitem=true; //Incase we stop dragging an item we dont want to redrag a new one.
					if(itemBeingDragged == item) //We clicked the item, then clicked it again
					{
						
						
					// if (cSheetFound)
					// TODO		GetComponent(Character).UseItem(item,0,true); //We use the item.


						ClearDraggedItem(); //Stop dragging
						dragitem = false; //Dont redrag
					}
					if (Event.current.button == 0) //Check to see if it was a left click
					{
						if(dragitem)
						{
							if (p.isEquipment == true) //If it's equipment
							{
								itemBeingDragged = item; //Set the item being dragged.
								draggedItemSize=itemIconSize; //We set the dragged icon size to our item button size.
								//We set the position:
								draggedItemPosition.y=Screen.height-Input.mousePosition.y-15;
								draggedItemPosition.x=Input.mousePosition.x+15;
							}

						}
					}
				}

			

			
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


	//Update the inv list
	public void UpdateInventoryList()
	{
		UpdatedList = associatedInventory.content;
		//Debug.Log("Inventory Updated");
	}

	public void ClearDraggedItem()
	{
		itemBeingDragged=null;
	}

}
