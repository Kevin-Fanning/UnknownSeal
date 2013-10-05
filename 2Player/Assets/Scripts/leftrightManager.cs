using UnityEngine;
using System.Collections;

public class leftrightManager : MonoBehaviour {
	
	public Font myFont;
	
	int score1, score2;
	int acceleration1, acceleration2;
	
	string lastPlayer1, lastPlayer2;
	
	public Transform player1, player2;
	public Transform pointer;
	
	string gameTitle = "LEFT, RIGHT, LEFT, RIGHT";
	
	public void Start()
	{
		StartCoroutine("title");	
	}
	
	public void Update()
	{
		player1.localScale = new Vector3(score1, player1.localScale.y, 1.0f);
		player2.localScale = new Vector3(score2, player2.localScale.y, 1.0f);	
		
		if (!pointer.renderer.enabled)
		{
			if (score1 >= 768)
			{
				pointer.transform.rotation = Quaternion.Euler(0, 0, 0);
				pointer.renderer.enabled = true;
				controls.p1Wins++;
				StartCoroutine("timeout");
			}
			else if (score2 >= 768)
			{
				controls.p2Wins++;
				pointer.transform.rotation = Quaternion.Euler(0, 0, 180);
				pointer.renderer.enabled = true;
				StartCoroutine("timeout");
			}
		}
	}
	
	IEnumerator timeout()
	{
		yield return new WaitForSeconds(2.0f);
		
		pointer.renderer.enabled = false;
		score1 = 0;
		score2 = 0;
		acceleration1 = 1;
		acceleration2 = 1;
		
		
		Application.LoadLevel (controls.lvls[++controls.currentLevel]);
	}
	
	IEnumerator title()
	{
		yield return new WaitForSeconds(2.0f);
		
		gameTitle = "";
	}
	
	public void left(int player)
	{
		if (player == 1)
		{
			if (lastPlayer1 == "RIGHT")
			{
				score1 += acceleration1;
				acceleration1++;
			}
			else
			{
				acceleration1--;
				acceleration1 = Mathf.Max(1, acceleration1);
			}
			lastPlayer1 = "LEFT";
		}
		else if (player == 2)
		{
			if (lastPlayer2 == "RIGHT")
			{
				score2 += acceleration2;
				acceleration2++;
			}
			else
			{
				acceleration2--;
				acceleration2 = Mathf.Max(1, acceleration2);
			}
			lastPlayer2 = "LEFT";
		}
	}
	
	public void right(int player)
	{
		if (player == 1)
		{
			if (lastPlayer1 == "LEFT")
			{
				score1 += acceleration1;
				acceleration1++;
			}
			else
			{
				acceleration1--;
				acceleration1 = Mathf.Max(1, acceleration1);
			}
			lastPlayer1 = "RIGHT";
		}
		else if (player == 2)
		{
			if (lastPlayer2 == "LEFT")
			{
				score2 += acceleration2;
				acceleration2++;
			}
			else
			{
				acceleration2--;
				acceleration2 = Mathf.Max(1, acceleration2);
			}
			lastPlayer2 = "RIGHT";
		}
	}
	
	public void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.fontSize = 80;
		style.font = myFont;
		style.normal.textColor = Color.yellow;
		style.alignment = TextAnchor.MiddleCenter;
		
		GUI.Label (new Rect(0, 0, 768, 1280), gameTitle, style);
//		GUI.Label (new Rect(0, 900, 768, 120), score1.ToString ());
//		GUI.Label (new Rect(0, 950, 768, 120), lastPlayer1);
//		GUI.Label (new Rect(0, 1000, 768, 120), acceleration1.ToString ());
//
//		Matrix4x4 orig = GUI.matrix;
//		GUIUtility.RotateAroundPivot(180.0f, new Vector2(384, 640));
//			
//		GUI.Label (new Rect(0, 900, 768, 120), score2.ToString ());
//		GUI.matrix = orig;
	}
}
