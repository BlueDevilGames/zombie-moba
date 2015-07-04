using UnityEngine;
using System.Collections;

public class Nexus : Static {

	public GameObject minionToSpawn;
	public Vector3 minionSpawnLocationTop;
	public Vector3 minionSpawnLocationBot;
	public Vector3 minionDestLocationTop;
	public Vector3 minionDestLocationBot;
 	
	int timeOneFrameAgo;

	// Use this for initialization
	public override void Start () {
		timeOneFrameAgo = 0;
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		int curTime = timer.GetCurrentTime ();
		SpawnMinion(curTime);
		base.Update ();
	}

	int mod(int a, int b) {
		int quotient = a / b;
		return a - (b * quotient);
	}

	void SpawnMinion(int curTime) {
		if (curTime%5 == 0 && curTime > timeOneFrameAgo) {
			GameObject minionTop = Instantiate(minionToSpawn);
			GameObject minionBot = Instantiate(minionToSpawn);
			minionTop.GetComponent<Minion>().team = team;
			minionBot.GetComponent<Minion>().team = team;
			minionTop.transform.position = minionSpawnLocationTop;
			minionBot.transform.position = minionSpawnLocationBot;
			minionTop.SendMessage("SetFinalDestination", minionDestLocationTop);
			minionBot.SendMessage("SetFinalDestination", minionDestLocationBot);
		}

		timeOneFrameAgo = curTime;
	}

}
