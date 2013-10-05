using UnityEngine;
using System.Collections;

public class touchScript : MonoBehaviour {
	
	public int clickablesSize;
	public GameObject[] clickables;
	bool[] hasBeenClicked;

	
	// Use this for initialization
	public void Start () {
		hasBeenClicked = new bool[clickablesSize];
	}
	
	// Update is called once per frame
	public void Update () {
		int i = 0;
		foreach (Touch touch in Input.touches)
		{
			i = 0;
			foreach (GameObject go in clickables)
			{
				Vector2 goPosition = Camera.main.WorldToScreenPoint(go.transform.position);
				if (Intersects (touch.position, new Rect(goPosition.x - go.transform.localScale.x/2, goPosition.y - go.transform.localScale.y/2, go.transform.localScale.x, go.transform.localScale.y)))
				{
					if (!hasBeenClicked[i])
						go.SendMessage ("onClick");
					hasBeenClicked[i] = true;
				}
				i++;
			}
		}
		
		i = 0;
		foreach (GameObject go in clickables)
		{
			if (!hasBeenClicked[i])
			{
				go.SendMessage ("noClick");	
			}
			i++;
		}
		
		for (int j = 0; j < clickablesSize; j++)
		{
			hasBeenClicked[j] = false;	
		}
	}
	
	public bool Intersects(Vector2 point, Rect rect)
	{
		if (point.x < rect.xMax && point.x > rect.xMin &&
			point.y < rect.yMax && point.y > rect.yMin)
		{
			return true;	
		}
		return false;
	}
}
