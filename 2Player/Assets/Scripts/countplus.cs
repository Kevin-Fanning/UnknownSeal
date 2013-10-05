using UnityEngine;
using System.Collections;

public class countplus : MonoBehaviour {

	public GameObject linkedCounter;
	counter countScript;
	
	public void Start()
	{
		countScript = linkedCounter.GetComponent<counter>();
	}
	
	public void onClick()
	{
		countScript.add ();
	}
}
