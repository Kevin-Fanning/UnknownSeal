using UnityEngine;
using System.Collections;

public class minus : MonoBehaviour {

	public GameObject linkedCounter;
	counter countScript;
	
	bool wasLastClicked = false;
	
	public void Start()
	{
		countScript = linkedCounter.GetComponent<counter>();
	}
	
	public void onClick()
	{
		if (!wasLastClicked)
		{
			countScript.subtract ();
			wasLastClicked = true;
		}
	}
	
	public void noClick()
	{
		wasLastClicked = false;
	}
}
