using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InhibBehavior : MonoBehaviour {

	public List<Inhibitor> inhibitors;
	public int tickDamage;
	private List<Unit> affectedUnits;
	private GameTimer gameTimer;
	private int lastTickTime;

	// Use this for initialization
	void Start () {
		inhibitors = new List<Inhibitor>();
		affectedUnits = new List<Unit>();
		gameTimer = GameObject.FindGameObjectWithTag ("gameTimer").GetComponent<GameTimer>();
		lastTickTime = -1000;
	}
	
	// Update is called once per frame
	void Update () {
		int damageMultiplier = 0;
		foreach (Inhibitor inhib in inhibitors) {
			if(!inhib.isDead()) {
				damageMultiplier ++;
			}
		}
		affectedUnits.RemoveAll (item => (item == null || item.Equals(null)));
		foreach(Unit unit in affectedUnits) {

			if(gameTimer.GetCurrentTimeMillis() - 1000 > lastTickTime) {
				unit.TakeDamage(tickDamage * damageMultiplier);
				lastTickTime = gameTimer.GetCurrentTimeMillis();
			}

		}
	}

	void OnTriggerEnter (Collider other) {
		Unit unit = other.gameObject.GetComponent<Unit> ();
		if (unit != null && inhibitors.Count != 0 && unit.team != inhibitors [0].team && unit.team != 0) {
			affectedUnits.Add(unit);
		}
	}

	void OnTriggerExit (Collider other) {
		Unit unit = other.gameObject.GetComponent<Unit> ();
		if (unit != null && inhibitors.Count != 0 && unit.team != inhibitors [0].team && unit.team != 0) {
			affectedUnits.Remove(unit);
		}
	}
}
