using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class GameTimer : MonoBehaviour {

	public Text timeText;

	DateTime timeUpdate;
	DateTime timeStart;
	int curTimeSec;
	int curTimeMillis;
	bool onTheSecond;

	// Use this for initialization
	void Start () {
		timeStart = DateTime.Now;
		timeUpdate = timeStart;
	}
	
	// Update is called once per frame
	void Update () {
		DateTime temp = DateTime.Now;
		if (temp.Second != timeUpdate.Second) {
			Debug.Log(temp.Second);
			Debug.Log (timeUpdate.Second);
			onTheSecond = true;
		}
		else {
			onTheSecond = false;
		}
		timeUpdate = temp;
		curTimeSec = (int) (timeUpdate - timeStart).TotalSeconds;
		curTimeMillis = (int) (timeUpdate - timeStart).TotalMilliseconds;
		updateGameTime (curTimeSec);
	}

	void updateGameTime(int curTimeSec) {
		int hours = 0;
		int minutes = curTimeSec / 60;
		if (minutes > 60) {
			hours = minutes / 60;
			minutes = minutes % 60;
		}
		int seconds = curTimeSec % 60;

		timeText.text = timeToText (hours) + ":" + timeToText(minutes) + ":" + timeToText (seconds);
	}

	private String timeToText(int time){
		if (time < 10) {
			return "0" + time.ToString();
		} else {
			return time.ToString();
		}
	}

	public int GetCurrentTimeSec() {
		return curTimeSec;
	}

	public int GetCurrentTimeMillis() {
		return curTimeMillis;
	}

	public bool IsOnTheSecond() {
		return onTheSecond;
	}

}
