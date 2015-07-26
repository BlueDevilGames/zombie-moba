using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemScript : MonoBehaviour {

	public int durability;
	private GameTimer gameTimer;
	private int timeLeftSeconds;
	private int lastCheck;
	private List<IEffect> itemEffects;

	// Use this for initialization
	void Start () {
		gameTimer = GameObject.FindGameObjectWithTag ("gameTimer").GetComponent<GameTimer>();
		timeLeftSeconds = durability;
		lastCheck = gameTimer.GetCurrentTimeSec ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeLeftSeconds == 0) {
			Destroy(this);
		}
		if (gameTimer.IsOnTheSecond ()) {
			timeLeftSeconds --;
		}
	}

	void repair(int incr) {
		timeLeftSeconds += incr;
		if (timeLeftSeconds > durability) {
			timeLeftSeconds = durability;
		}
	}
}
