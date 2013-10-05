using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	
	public GUISkin mySkin;
	
	void OnGUI()
	{
		
		GUI.skin = mySkin;
		
		GUI.Label (new Rect(100, 200, 568, 400), "MINI GAEMS FOR FUN AND PROFIT");
		
		if (GUI.Button (new Rect(100, 650, 568, 300), "START GAME"))
		{
			controls.p1Wins = 0;
			controls.p2Wins = 0;
			controls.currentLevel = 0;
			
			for (int i = 4; i > 0; i--)
			{
				int j = Random.Range (0, i+1);
				int tmp = controls.lvls[i];
				controls.lvls[i] = controls.lvls[j];
				controls.lvls[j] = tmp;
			}
			Application.LoadLevel (controls.lvls[controls.currentLevel]);	
			
			
		}
		
		
	}
}
