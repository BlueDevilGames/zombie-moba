using UnityEngine;
using System.Collections;
using System;

public class GameTimer : MonoBehaviour {

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
