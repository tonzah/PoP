using UnityEngine;
using System.Collections;


public class DragAndDrop  : MonoBehaviour
{

		public void DoMyWindow (int windowId)
		{
				Texture textToUse;

				Potion currentInventoryItem;
			
				var mousePos = Input .mousePosition;
	
				//Go through each row
	
				for (var i = 0; i < inventory.length; i ++) {
		
						// and each column
		
						for (var k = 0; k < inventory[i].length; k ++) {
			
								currentInventoryItem = inventory [i] [k];
					
								//if there is an item in the i-th row and the k-th column, draw it
			
								if (inventory [i] [k] == null) {
				
										GUI .DrawTexture (new Rect (offSet.x + k * (iconWidthHeight + spacing), offSet.y + i * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight), emptyTex);
				
								} else {
				
										GUI .DrawTexture (new Rect (offSet.x + k * (iconWidthHeight + spacing), offSet.y + i * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight), currentInventoryItem.texRepresentation);
				
				
				
								}
			
			
			
								var Slot = 	GUI .Button (new Rect (offSet.x + k * (iconWidthHeight + spacing), offSet.y + i * (iconWidthHeight + spacing), iconWidthHeight, iconWidthHeight), "", GUIStyle ("label"));
			
								InvCloseBtn = GUI .Button (new Rect (210, 9, 24, 24), "", GUIStyle ("button"));
			
			
			
								if (InvCloseBtn) {
				
										// print ("Inventory Closed");
				
										ShowInventory = false;
				
				
				
								}    
		
			
								if (currentInventoryItem != null && Slot) {
			
										currentInventoryItem.worldObject.transform.position = transform.position;
				
										currentInventoryItem.worldObject.transform.rotation = transform.rotation;
				
										currentInventoryItem.worldObject.active = true;
				
										initPt = Input .mousePosition;  
				
										var rect = Rect (0, 0, 238, 300);
				
				
				
										if (rect.Contains (Event.current .mousePosition)) {
					
												print ("Mouse is inside the rect" + initPt); 
					
												GUI .DrawTexture (new Rect ((initPt.x), (Screen .height - initPt.y), iconWidthHeight, iconWidthHeight), currentInventoryItem.texRepresentation); 
									
										}
								
										if (Input .GetMouseButtonUp (0)) {       
					
												//Equip it
					
												currentInventoryItem.worldObject.transform.parent = transform;
					
												inventory [i] [k] = null;
					
					
					
										} else if (Input .GetMouseButtonUp (1)) {
					
												//Drop it
					
												inventory [i] [k] = null; 
					
												currentInventoryItem.worldObject.transform.parent = null;
				
										}             
				
								}
			
						}
		
				}       

				GUI .DragWindow (Rect (0, 0, 10000, 35));
	
		}

}