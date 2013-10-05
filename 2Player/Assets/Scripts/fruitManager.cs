using UnityEngine;
using System.Collections;

public class fruitManager : MonoBehaviour {
	public GUISkin mySkin;
	Color[] colors = {Color.red, Color.cyan, Color.yellow, Color.green, Color.yellow, Color.white};
	string[] choices = {"LYCHEE", "CHINESE DATE", "GUAVA", "APPLE", "WATERMELON", "CUCUMBER", "LUNGAN", "PLANTAIN", "INDIAN FIG", 
		"GUANABANA", "TOMATO", "EGGPLANT", "CHILI PEPPER", "GOURD", "CARROT", "DORITOS", "FILET MIGNON", "FROOT LOOPS", "WOODPECKER", 
		"URINAL CAKE", "CREME FRAICHE", "BROCCOLI", "HASKELL", "SASSAFRAS", "YOUR MOTHER", "THE SEVENTIES", "1984", "SWEDISH FISH" };
	//28 choices. x < 14 means fruit
	public Transform player1;
	public Transform player2;
	public Transform pointer;
	
	int score1, score2;
	
	int randA, randB, randC;
	int skipValue;
	
	int currentItem;
	
	string outputString;
	
	float lastTime;
	
	// Use this for initialization
	void Start () {
		
		score1 = 0; 
		score2 = 0;
		
		currentItem = Random.Range (0, 28);
		
		randA = Random.Range (1, 15);
		randB = Random.Range (1, 15);
		randC = Random.Range (1, 15);
		
		skipValue = randA*28*28 + randB*28 + randC;
		
		outputString = "CLICK FOR FRUIT!";
		
		lastTime = Time.time;
	}
	
	void aFruit(int player)
	{
		if (!pointer.renderer.enabled)
		{
			pointer.renderer.enabled = true;
			if (currentItem < 14)
			{
				if (player == 1)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 0);
					score1++;
				}
				else if (player == 2)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 180);
					score2++;
				}
			}
			else
			{
				if (player == 1)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 180);
					score2++;
				}
				else if (player == 2)
				{
					pointer.rotation = Quaternion.Euler (0, 0, 0);
					score1++;
				}
			}
			if (score1 == 5 || score2 == 5)
			{
				if (score1 == 5) 
					controls.p1Wins++;
				if (score2 == 5)
					controls.p2Wins++;
				StartCoroutine ("gameover");
			}
			else
			{
				StartCoroutine ("timeout");
			}
		}	
	}
	
	IEnumerator gameover()
	{
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel (controls.lvls[++controls.currentLevel]);
	}
	
	IEnumerator timeout()
	{
		yield return new WaitForSeconds(2.0f);
		
		currentItem = nextChoice ();
		outputString = choices[currentItem];
		if (currentItem == 28) currentItem--;
		mySkin.label.normal.textColor = colors[Random.Range (0, 6)];
		pointer.renderer.enabled = false;
		lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - lastTime > 2.5f && !pointer.renderer.enabled)
		{
			currentItem = nextChoice ();
			outputString = choices[currentItem];
			if (currentItem == 28) currentItem--;
			mySkin.label.normal.textColor = colors[Random.Range (0, 6)];
			pointer.renderer.enabled = false;
			lastTime = Time.time;
		}
		
		if (Time.time - lastTime > 4.5f)
		{
			pointer.renderer.enabled = false;	
		}
	}
	
	void OnGUI()
	{
		GUI.skin = mySkin;
		GUI.Label (new Rect(0, 900, 768, 120), outputString);

		Matrix4x4 orig = GUI.matrix;
		GUIUtility.RotateAroundPivot(180.0f, new Vector2(384, 640));
			
		GUI.Label (new Rect(0, 900, 768, 120), outputString);
		GUI.matrix = orig;	
	}
	
	int nextChoice()
	{
		//modulo by the next highest prime past the length of the list. should be pseudo-random
		Debug.Log (currentItem);
		Debug.Log (skipValue);
		Debug.Log ((currentItem + skipValue)%29);
		return (currentItem + skipValue) % 29;	
		
	}
}
