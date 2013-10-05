using UnityEngine;
using System.Collections;

public class equationRightWrong : MonoBehaviour {

	public Transform manager;
	
	public bool Right;
	public int player;
	
	void onClick()
	{
		if (!Right)
		{
			manager.GetComponent<equationManager>().SendMessage ("Wrong", player);
		}
		else
		{
			manager.GetComponent<equationManager>().SendMessage("Right", player);
		}
	}
}
