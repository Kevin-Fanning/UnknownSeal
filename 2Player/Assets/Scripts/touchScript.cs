using UnityEngine;
using System.Collections;

public class touchScript : MonoBehaviour {
	
	public int clickablesSize;
	public GameObject[] clickables;

	
	// Use this for initialization
	public void Start () {

	}
	
	// Update is called once per frame
	public void Update () {
		foreach (Touch touch in Input.touches)
		{
			//i = 0;
			foreach (GameObject go in clickables)
			{
				Vector2 goPosition = Camera.main.WorldToScreenPoint(go.transform.position);
				if (touch.phase == TouchPhase.Began && Intersects (touch.position, new Rect(goPosition.x - go.transform.localScale.x/2, goPosition.y - go.transform.localScale.y/2, go.transform.localScale.x, go.transform.localScale.y)))
				{
					go.SendMessage("onClick");
				}
				
			}
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
