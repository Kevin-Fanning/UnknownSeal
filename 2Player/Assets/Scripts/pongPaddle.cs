using UnityEngine;
using System.Collections;

public class pongPaddle : MonoBehaviour {
	
	Vector3 lerpTo;
	
	void Update()
	{
		//transform.position = Vector3.Lerp (transform.position, lerpTo, Time.time);
		transform.position = new Vector3(Mathf.Lerp (transform.position.x, lerpTo.x-384, Time.time) , transform.position.y, 1.0f);
	}
	
	void getCoord(Vector2 position)
	{
		lerpTo = new Vector3(position.x, this.transform.position.y, 1.0f);
	}
}
