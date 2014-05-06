using UnityEngine;
using System.Collections.Generic;

public class CraftManager : MonoBehaviour
{

	public List<GameObject> content = new List<GameObject> ();
	CraftTableDisplay display;
	public int MaxContent = 3;

	void Awake(){

		display = (CraftTableDisplay)this.gameObject.GetComponent (typeof(CraftTableDisplay));

		}


	public void AddItem(GameObject item)
	{

		content.Add (item);

		if (display != null)
		{
			display.UpdateInventoryList();
		}

	}
	public void RemoveItem(GameObject item)
	{
		int index=0;
		bool shouldend=false;
		foreach(GameObject i in content) //Loop through the Items in the Inventory:
		{
			if(i == item) //When a match is found, remove the Item.
			{
				content.RemoveAt(index);
				shouldend=true;
				//No need to continue running through the loop since we found our item.
			}
			index++;
			
			if(shouldend) //Exit the loop
			{
		//		Contents=newContents.ToBuiltin(Transform);

				if (display != null)
				{
					display.UpdateInventoryList();
				}
				return;
			}
		}

	}

}
