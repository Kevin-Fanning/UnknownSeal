using UnityEngine;
using System.Collections;

public class countManager : MonoBehaviour {
	
	public Transform objectToCount;
	public int magicNumber;
	public int max;
	public int min;
	
	public Transform player1;
	public Transform player2;
	
	public int timeLeft = 10;
	
	
	
	// Use this for initialization
	void Start () {
		magicNumber = Random.Range (min, max);
		
		for (int i = 0; i < magicNumber; i++)
		{
			Instantiate(objectToCount, new Vector3(Random.Range (-360, 296), Random.Range (-428, 428), 1), Quaternion.Euler(0, 0, Random.Range (0, 3)*90));
		}
		StartCoroutine ("timesUp");
	}
	
	IEnumerator timesUp()
	{
		for (int i = timeLeft; i > 0; i--)
		{
			yield return new WaitForSeconds(1.0f);
			timeLeft--;
		}
	}
}
