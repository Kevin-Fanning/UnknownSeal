using UnityEngine;
using System.Collections;

public class countminus : MonoBehaviour {

	public GameObject linkedCounter;
	counter countScript;
	
	
	public void Start()
	{
		countScript = linkedCounter.GetComponent<counter>();
	}
	
	public void onClick()
	{
		countScript.subtract ();
	}
}
