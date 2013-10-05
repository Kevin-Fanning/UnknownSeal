using UnityEngine;
using System.Collections;

public class plus : MonoBehaviour {

	public GameObject linkedCounter;
	counter countScript;
	int lastEvent;
	
	bool wasLastClicked = false;
	
	public void Start()
	{
		countScript = linkedCounter.GetComponent<counter>();
	}
	
	public void onClick()
	{
		if (!wasLastClicked)
		{
			countScript.add ();
			wasLastClicked = true;
		}
	}
	
	public void noClick()
	{
		wasLastClicked = false;
	}
}
