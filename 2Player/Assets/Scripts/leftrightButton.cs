using UnityEngine;
using System.Collections;

public class leftrightButton : MonoBehaviour {
	
	public Transform manager;
	
	public bool isRight;
	public int player;
	
	//bool lastClick = false;
	
	float lastTime;
	
	void Update()
	{
		
	}
	
	void onClick()
	{
		if (isRight)
		{
			manager.GetComponent<leftrightManager>().SendMessage("right", player);
		}
		else
		{
			manager.GetComponent<leftrightManager>().SendMessage("left", player);
		}
	}
	
//	void noClick()
//	{
//		lastClick = false;
//	}
	
	void OnGUI()
	{
		//GUI.Label(new Rect(250 + (isRight ? 250 : 0) , 700 - 100*player, 300, 200), lastClick.ToString ());
	}
}
