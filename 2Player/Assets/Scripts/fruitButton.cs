using UnityEngine;
using System.Collections;

public class fruitButton : MonoBehaviour {

	public Transform manager;
	public int player;
	
	void onClick()
	{
		manager.GetComponent<fruitManager>().SendMessage ("aFruit", player);
	}
}
