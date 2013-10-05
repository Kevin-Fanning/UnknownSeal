using UnityEngine;
using System.Collections;

public class end : MonoBehaviour {

	public GUISkin mySkin;
	
	void OnGUI()
	{
		GUI.skin = mySkin;
		
		if (controls.p1Wins > controls.p2Wins)
		{
		GUI.Label (new Rect(100, 0, 568, 1280), "PLAYER ONE WINS!");
		}
			else if (controls.p2Wins > controls.p1Wins)
		{
			GUI.Label (new Rect(100, 0, 568, 1280), "PLAYER TWO WINS!");
		}
		else
		{
			GUI.Label (new Rect(100, 0, 568, 1280), "IT'S A DRAW!");
		}
		
		if(GUI.Button (new Rect(100, 800, 568, 400), "PLAY AGAIN"))
		{
			Application.LoadLevel (0);	
		}
	}
}
