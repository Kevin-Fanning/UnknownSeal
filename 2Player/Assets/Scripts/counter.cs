using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour {

	public int count = 0;
	public bool player1 = false;
	public Transform manager;
	
	public Font myFont;
	
	int timeLeft;
	
	public void add()
	{
		if (timeLeft > 0)
			count += 1;	
	}
	
	public void subtract()
	{
		if (timeLeft > 0)
			count = count > 0 ? count - 1 : 0;	
	}
	
	public void OnGUI()
	{
		GUIStyle style = new GUIStyle();
		style.font = myFont;
		style.normal.textColor = Color.yellow;
		timeLeft = manager.GetComponent<countManager>().timeLeft;
		if (player1)
		{
			GUI.Label (new Rect(284, 1200, 100, 60), count.ToString (), style);
			GUI.Label (new Rect(284, 1050, 100, 60), timeLeft > 8 ? "COUNT!" : timeLeft.ToString (), style);
		}
		else
		{
			Matrix4x4 orig = GUI.matrix;
			GUIUtility.RotateAroundPivot(180.0f, new Vector2(384, 640));
			
			GUI.Label (new Rect(284, 1200, 100, 60), count.ToString (), style);
			GUI.Label (new Rect(284, 1050, 100, 60), timeLeft > 8 ? "COUNT!" : timeLeft.ToString (), style);
			GUI.matrix = orig;
		}
	}
}
