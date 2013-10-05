using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	public GUISkin mySkin;
	
	void OnGUI()
	{
		
		GUI.skin = mySkin;
		
		GUI.Label (new Rect(284, 100, 200, 100), "UNKNOWN SEAL");
		
		if (GUI.Button (new Rect(284, 250, 200, 200), "START GAME"))
		{
			Application.LoadLevel (1);	
		}
		
		
	}
}
