using UnityEngine;
using System.Collections;

public class pongBall : MonoBehaviour {
	
	public Transform pointer;
	
	Vector3 Velocity;
	// Use this for initialization
	void Start () {
		Velocity = new Vector3(-200.0f, -350.0f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position += Velocity*Time.deltaTime;
		
		if (transform.position.x < -384)
		{
			Velocity = new Vector3(200.0f, Velocity.y, 0);
		}
		
		if (transform.position.x > 384)
		{
			Velocity = new Vector3(-200.0f, Velocity.y, 0);
		}
		
		if (pointer.renderer.enabled == false)
		{
			if (transform.position.y > 640)
			{
				pointer.rotation = Quaternion.Euler (0, 0, 0);
				pointer.renderer.enabled = true;
				controls.p1Wins++;
				StartCoroutine("timeout");
			}
			else if (transform.position.y < -640)
			{
				pointer.rotation = Quaternion.Euler (0, 0, 180);
				pointer.renderer.enabled = true;
				controls.p2Wins++;
				StartCoroutine("timeout");
			}
		}
	}
	
	IEnumerator timeout()
	{
		yield return new WaitForSeconds(2.0f);
		
		pointer.renderer.enabled = false;
		
		Application.LoadLevel (controls.lvls[++controls.currentLevel]);
	}
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log (Velocity.y.ToString());
		if (other.tag == "paddle2" && this.transform.position.y < 550)
		{
			float distance = other.transform.position.x - this.transform.position.x;
			Velocity = new Vector3(Velocity.x - distance*5.0f/3.0f, Mathf.Max(-1*Velocity.y * 1.1f, -1700), 0);
		}
		
		if (other.tag == "paddle1" && this.transform.position.y > -550)
		{
			float distance = other.transform.position.x - this.transform.position.x;
			Velocity = new Vector3(Velocity.x - distance*5.0f/3.0f, Mathf.Min (-1*Velocity.y * 1.1f, 1700), 0);
		}
	}
}
