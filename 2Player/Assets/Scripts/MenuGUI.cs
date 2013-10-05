using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {

	void OnGUI()
	{
		GUI.Label (new Rect(10, 10, 200, 30), "Unknown Seal");
		
		if (GUI.Button (new Rect(10, 50, 200, 200), "Start Game"))
		{
			Application.LoadLevel (1);	
		}
		
		
	}
}
