using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KK : MonoBehaviour {

Texture2D highlight;
Texture2D activated;
Texture2D slotBG;

List<Potion> inventory =  new List<Potion>();

	List<GameObject> clickInfo = new List<GameObject>();
	List<GameObject> hoverInfo = new List<GameObject>();						// List of bag classes, rects, and requirements

	bool dragMode = false;
List<Potion> crafttable = new List<Potion>();

void Awake  () {

		Input.multiTouchEnabled = true;
		inventory.Add(new Firestone());
		highlight = (Texture2D)Resources.Load("slot-highlight");
		activated = (Texture2D)Resources.Load("slot-active-highlight");
		slotBG = (Texture2D)Resources.Load("slots-bg");

}

void Start() {
	

	}

void Update (){

		if (Input.touchCount == 1)
			storeMouseLoc ();
		if (Input.touchCount == 1)
						dragCheck ();
				if (Input.touchCount == 0)
						compareMouseLoc ();
		}

		
void OnGUI(){
	// Reset mouse over info to null
		hoverInfo = null
	
	// Draw the slot backgrounds
	GUI.DrawTexture(new Rect(200,200,349,30), slotBG);
	GUI.DrawTexture(new Rect(200,234,349,30), slotBG);
	
	// Add to buttons
	/*if(GUI.Button(Rect(200,300,200,25), "Add items to action bar")){
		var openSlot = getNextSlot(inventory);
		if(openSlot != -1){
			inventory[openSlot][0] = new classEvilSmile();
		}
	}
	if(GUI.Button(Rect(200,330,200,25), "Add items to bags")){
		openSlot = getNextSlot(crafttable);
		if(openSlot != -1)
			crafttable[openSlot][0] = new classFistPunch();
	}*/
	
	// Draw Bag GUI
	for(int i=0; i < inventory.Count; i++){
		// If there is an item class in the slot, draw the button
		if(inventory[i] != null)
			drawButton(inventory[i], inventory[i].icon, i, inventory);
		// Otherwise just check if the mouse is over the rect
		else
			checkRectHover(inventory[i], null, i, inventory);
	}
	
	// Draw Action Bar GUI
	for(int i=0; i<crafttable.Count; i++){
		// If there is an item class in the slot, draw the button
		if(crafttable[i]!= null)
			drawButton(crafttable[i], crafttable[i][0].icon, i, crafttable);
		// Otherwise just check if the mouse is over the rect
		else
			checkRectHover(crafttable[i], null, i, crafttable);
	}
	
	// Handle keyboard input
	getKeyInput();
	
	// If we are dragging, draw the drag icon
	if(dragMode)	drawDragIcon();
}

// Custom function to draw a GUI icon and store information at the same time
	void drawButton(Rect rect, Texture2D image, int index, List<GameObject> pointer){
	bool drawIcon  = true;								// Boolean for if we should draw the icon (dragging)
	if(clickInfo.Count > 0)											// If there was a previous click
		if(clickInfo[0] == rect && dragMode)					// If the clicked rectangle is this rect and we are dragging
			drawIcon = false;										// Dont draw the icon
	if(drawIcon)														// If we are good to draw the icon
		GUI.DrawTexture(rect, image);							// Draw the icon
	checkRectHover(rect, image, index, pointer);			// Now check if the mouse is hovering over the rect
}

// Checks if mouse is hovering over a rect
void checkRectHover(Rect rect,Texture2D image,int index,List<GameObject> pointer){
	if(rect.Contains(getMousePos())){							// Check for mouse over
		hoverInfo.(rect);										// Store the rect info
		hoverInfo.Push(image);										// Store the icon info
		hoverInfo.Push(index);										// Store the index info
		hoverInfo.Push(pointer[index][0]);						// Store if slot contains an obj
		hoverInfo.Push(pointer);									// Pointer to class array
		hoverInfo.Push(getMousePos());						// Store click position
		if(pointer[index]){										// If there is an item that our mouse is over
			if(!Input.GetMouseButton(0))
				GUI.DrawTexture(rect, highlight);				// Draw mouse over highlight
			else
				GUI.DrawTexture(rect, activated);				// Draw in use highlight
		}
	}
}

// Stores current location on mouse down, only if we are above an item
void storeMouseLoc(){
	if(hoverInfo.Count > 0 && hoverInfo[3] != null)
		clickInfo = hoverInfo;
}

// Checks for mouse dragging
void dragCheck(){
	if(clickInfo.Count > 0)
		if((getMousePos() - clickInfo[5]).sqrMagnitude > 60) dragMode = true;
}

// Function that checks for keyboard input from user

void compareMouseLoc(){
	// If we clicked a slot, and we are above a slot now, and there was an item in the previous slot
	if(hoverInfo.Count > 0 && clickInfo.Count > 0){
		// If we are in the same bar and same location and not dragging, use the item
		if(hoverInfo[2] == clickInfo[2] && checkReq(clickInfo[4][hoverInfo[2]][0].type, hoverInfo[4][hoverInfo[2]][2]) && !dragMode){
			// If there is an item in the slot, use it
			if(clickInfo[4][clickInfo[2]][0]){
				clickInfo[4][clickInfo[2]][0].use();
			}
		}
		// If we are in the same bar and same location and dragging, do nothing
		if(hoverInfo[2] == clickInfo[2] && hoverInfo[4] == clickInfo[4] && dragMode){
		}
		// If there is an item in the slot we are moving to
		if(hoverInfo[4][hoverInfo[2]][0]){
			var clickedItemReq = checkReq(clickInfo[4][clickInfo[2]][0].type, hoverInfo[4][hoverInfo[2]][2]);
			var hoverItemReq = checkReq(hoverInfo[4][hoverInfo[2]][0].type, clickInfo[4][clickInfo[2]][2]);
			if(clickedItemReq && hoverItemReq){
				var clickSwap = clickInfo[4][clickInfo[2]][0];
				var hoverSwap = hoverInfo[4][hoverInfo[2]][0];
				clickInfo[4][clickInfo[2]][0] = hoverSwap;
				hoverInfo[4][hoverInfo[2]][0] = clickSwap;
			}
		}
		// If the slot is empty that we are moving to
		else{
			// Check if click item can move to empty slot
			if(checkReq(clickInfo[4][clickInfo[2]][0].type, hoverInfo[4][hoverInfo[2]][2])){
				hoverInfo[4][hoverInfo[2]][0] = clickInfo[4][clickInfo[2]][0];
				clickInfo[4][clickInfo[2]][0] = null;
			}
		}
	}
	// If we clicked an item, but are not above an item now, destroy the item
	else if(hoverInfo.Count == 0 && clickInfo.Count > 0){
		clickInfo[4][clickInfo[2]][0] = null;
	}
	clickInfo = clickInfo.RemoveAll();   // Reset mouse clickInfo
	dragMode = false;     // Reset dragMode
}

// Returns a rect that is slightly smaller then the given rect
Rect getHoverRect(Rect hoverRect){
	hoverRect.x += 1;
	hoverRect.y += 1;
	hoverRect.width -= 1;
	hoverRect.height -= 1;
	return hoverRect;
}

// Returns the next available open slot in specified list, -1 if none found
int getNextSlot(List<Potion> list){
	var slotFound = -1;
	for(int i=0; i<list.Count; i++){
		if(!list[i][0]){
			slotFound = i;
			break;
		}
	}
	return slotFound;
}

// Returns true or false if item meets list requirements
bool checkReq(Potion item, List<Potion> list){
	var result = false;
	for(int i=0; i<list.Count; i++){
		if(item == list[i]){
			result = true;
			break;
		}
	}
	return result;
}

// Draws the icon that is dragging
void drawDragIcon(){
	var pos = getMousePos();
	GUI.DrawTexture(new Rect(pos.x - 15, pos.y - 15, 24, 24), clickInfo[1]);
}

// Returns the real mouse position
Vector2 getMousePos(){
	Vector2 pos = new Vector2(Input.mousePosition.x, (Screen.height - Input.mousePosition.y));
	return pos;
}

// Function that checks for keyboard input from user
void getKeyInput(){
	for(int i=0; i<inventory.Count; i++){
		if(Input.GetKey(inventory[i]) && inventory[i]){
			GUI.DrawTexture(inventory[i], activated);
		}
		else if(Input.GetKeyUp(inventory[i]) && inventory[i]){
			inventory[i][0].use();
		}
	}
}
}


