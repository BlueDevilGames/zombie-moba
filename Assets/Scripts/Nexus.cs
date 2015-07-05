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
			GameObject minionTop = (GameObject) Instantiate(minionToSpawn, minionSpawnLocationTop, Quaternion.identity);
			GameObject minionBot = (GameObject) Instantiate(minionToSpawn, minionSpawnLocationBot, Quaternion.identity);
			minionTop.GetComponent<Minion>().team = team;
			minionBot.GetComponent<Minion>().team = team;
			minionTop.GetComponent<Minion>().SetFinalDestination(minionDestLocationTop);
			minionBot.GetComponent<Minion>().SetFinalDestination(minionDestLocationBot);

			
			
			//			minionTop.SendMessage("SetFinalDestination", minionDestLocationTop);
//			minionBot.SendMessage("SetFinalDestination", minionDestLocationBot);
		}

		timeOneFrameAgo = curTime;
	}

}
