using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
 * This class is in charge of counting down the Time Limit Text. So every second it will decrease the timelimit until zero. Once it hits zero
 * it needs to call its method.
 * 
 * This class has a public method that's passed into it which is what is called when the timer is zero. 
 * 
 * */

public class Timer : MonoBehaviour
{
	public string timeLimitText = "Time: {0}s";
	public float timeLeft = 90;

	private Text timeLimit;

	// Use this for initialization
	void Start ()
	{
		timeLimit = GetComponent<Text> ();
		timeLimit.text = timeLimitText;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//update time left accordingly
		if (timeLeft < 1) {
			timeLeft = 0;
		} else {
			timeLeft -= Time.deltaTime;
		}

		//update timeLimitText
		timeLimit.text = string.Format (timeLimitText, Mathf.FloorToInt (timeLeft));
		Debug.Log (string.Format (timeLimitText, Mathf.FloorToInt (timeLeft)));
	}
}
