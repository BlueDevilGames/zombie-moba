using UnityEngine;
using System.Collections;
using System;

public class GameTimer : MonoBehaviour {

	DateTime timeUpdate;
	DateTime timeStart;
	int curTime;

	// Use this for initialization
	void Start () {
		timeStart = DateTime.Now;
	}
	
	// Update is called once per frame
	void Update () {
		timeUpdate = DateTime.Now;
		curTime = timeUpdate.Second - timeStart.Second;
	}

	public int GetCurrentTime() {
		return curTime;
	}

}
