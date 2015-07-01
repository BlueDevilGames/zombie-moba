using UnityEngine;
using System.Collections;

public class Tower : Static {

	Queue queue;
	Unit target;
	
	// Use this for initialization
	public override void Start () {
		queue = new Queue ();
		base.Start ();
	}
	
	// Update is called once per frame
	public override void Update () {
		if (target != null) {
			//ONLY DO THIS AT A CERTAIN RATE, needs a fix
			target.TakeDamage(curAttackDamage);
		}
		base.Update ();
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.GetComponent<Minion>() != null) {
			Minion minion = other.gameObject.GetComponent<Minion>();
			if(minion.team != team) {
				minion.GetComponent<NavMeshAgent>().SetDestination(GetComponent<Transform>().position);
				minion.updateTarget(this);
				if(target == null) {
					target = minion;
				}
				else {
					queue.Enqueue(minion);
				}
			}
		}

	}
}
