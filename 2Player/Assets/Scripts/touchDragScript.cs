using UnityEngine;
using System.Collections;

public class touchDragScript : MonoBehaviour {
	
	public Transform player1Receiver;
	public Transform player2Receiver;	
	
	string output, output2;
	
	// Update is called once per frame
	void Update () {
		Vector2 player1 = Vector2.zero;
		Vector2 player2 = Vector2.zero;
		foreach (Touch touch in Input.touches)
		{
			if (player1 == Vector2.zero && touch.position.y < 640)
			{
				player1 = touch.position;
			}
			else if (player2 == Vector2.zero && touch.position.y > 640)
			{
				player2 = touch.position;
			}
		}
		if (player1 != Vector2.zero)
			player1Receiver.SendMessage("getCoord", player1);
		if (player2 != Vector2.zero)
			player2Receiver.SendMessage("getCoord", player2);
	}
	
	void OnGUI()
	{
	}
}
