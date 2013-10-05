using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {


	void Awake () {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	
}
