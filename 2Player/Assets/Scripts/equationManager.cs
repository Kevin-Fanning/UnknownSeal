﻿using UnityEngine;
using System.Collections;

public class equationManager : MonoBehaviour { 
	public GUISkin mySkin;
	
	string[] equality = {"<", "=", ">"};
	string[] operations = {"+", "-", "x"};
	
	public string outputString;
	
	int equalizer;
	int operation;
	
	int num1, num2, num3;
	
	public bool answer;
	
	public Transform pointer;
	
	public int score1, score2;
	
	public void Start()
	{
		
		GenerateEquation ();
	}
	
	public void GenerateEquation()
	{
		num1 = Random.Range (0, 20);
		num2 = Random.Range (0, 20);
		
		operation = Random.Range (0, 3);
		equalizer = Random.Range (0, 3);
		
		int fudge = Random.Range (0, 2);
		
		if (operation == 0)
		{
			num3 = num1 + num2;
			
			
			if (equalizer == 0) // <
			{
				answer = num1 + num2 < num3 + fudge;
				outputString = num1.ToString() + " " + operations[0] + " " + num2.ToString () + " " + equality[0] + " " + (num3+ fudge);
				
			}
			else if (equalizer == 1)// = 
			{
				answer = num1 + num2 == num3 - fudge;
				outputString = num1.ToString() + " " + operations[0] + " " + num2.ToString () + " " + " " + equality[1] + " " + (num3- fudge);
				
			}
			else if (equalizer == 2)// >
			{
				answer = num1 + num2 > num3 - fudge;
				outputString = num1.ToString() + " " + operations[0] + " " + num2.ToString () + " " + " " + equality[2] + " " + (num3- fudge);
				
			}
		}
		else if (operation == 1)
		{
			num3 = num1 - num2;
			//num3 = Random.Range (num3 - 1, num3 + 1);
			
			if (equalizer == 0)
			{
				answer = num1 - num2 < num3 + fudge;
				outputString = num1.ToString() + " " + operations[1] + " " + num2.ToString () + " " + " " + equality[0] + " " + (num3+ fudge);
				
			}
			else if (equalizer == 1)
			{
				answer = num1 - num2 == num3 - fudge;
				outputString = num1.ToString() + " " + operations[1] + " " + num2.ToString () + " " + " " + equality[1] + " " + (num3- fudge);
				
			}
			else if (equalizer == 2)
			{
				answer = num1 - num2 > num3 - fudge;
				outputString = num1.ToString() + " " + operations[1] + " " + num2.ToString () + " " + " " + equality[2] + " " + (num3- fudge);
				
			}
		}
		else if (operation == 2)
		{
			num3 = num1 * num2;
			//num3 = Random.Range (num3 - 1, num3 + 1);
			
			if (equalizer == 0)
			{
				answer = num1 * num2 < num3 + fudge;
				outputString = num1.ToString() + " " + operations[2] + " " + num2.ToString () + " " + " " + equality[0] + " " + (num3+ fudge);
				
			}
			else if (equalizer == 1)
			{
				answer = num1 * num2 == num3 - fudge;
				outputString = num1.ToString() + " " + operations[2] + " " + num2.ToString () + " " + " " + equality[1] + " " + (num3- fudge);
				
			}
			else if (equalizer == 2)
			{
				answer = num1 * num2 > num3 - fudge;
				outputString = num1.ToString() + " " + operations[2] + " " + num2.ToString () + " " + " " + equality[2] + " " + (num3- fudge);
				
			}
		}
	}
	
	public void Wrong(int player)
	{
		if (!pointer.renderer.enabled)
		{
			pointer.renderer.enabled = true;
			if (!answer)
			{
				if (player == 1)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 0);
					score1++;
				}
				else if (player == 2)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 180);
					score2++;
				}
			}
			else
			{
				if (player == 1)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 180);
					score2++;
				}
				else if (player == 2)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 0);
					score1++;
				}
			}
			
			
			
			StartCoroutine ("timeout");
		}
	}
	public void Right(int player)
	{
		if (!pointer.renderer.enabled)
		{
			pointer.renderer.enabled = true;
			if (answer)
			{
				if (player == 1)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 0);
					score1++;
				}
				else if (player == 2)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 180);
					score2++;
				}
			}
			else
			{
				if (player == 1)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 180);
					score2++;
				}
				else if (player == 2)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 0);
					score1++;
				}
			}
			StartCoroutine ("timeout");
		}
	}
	
	IEnumerator gameover()
	{
		yield return new WaitForSeconds(2.0f);
		
		Application.LoadLevel (controls.lvls[++controls.currentLevel]);
	}
	IEnumerator timeout()
	{
		yield return new WaitForSeconds(2.0f);
		
		if (score1 == 5 || score2 == 5)
		{
			if (score1 == 5)
			{
				controls.p1Wins++;
				pointer.rotation = Quaternion.Euler (0, 0, 0);
			}
			if (score2 == 5)
			{
				controls.p2Wins++;
				pointer.rotation = Quaternion.Euler (0, 0, 180);
			}
			StartCoroutine("gameover");
		}
		else
		{
			pointer.renderer.enabled = false;
			GenerateEquation();
		}
	}
	
	public void OnGUI()
	{
		GUI.skin = mySkin;
		GUI.Label (new Rect(0, 900, 768, 120), outputString);

		Matrix4x4 orig = GUI.matrix;
		GUIUtility.RotateAroundPivot(180.0f, new Vector2(384, 640));
			
		GUI.Label (new Rect(0, 900, 768, 120), outputString);
		GUI.matrix = orig;
	}
	
}
