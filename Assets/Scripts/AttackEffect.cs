using UnityEngine;
using System.Collections;

public class AttackEffect : IEffect {

	public int plusAttack;
	
	void onKeyPress(KeyCode code) {

	}
	
	void addStats(Champion champion) {
		champion.baseAttackDamage += plusAttack;
		champion.updateStats ();
	}

	void removeStats(Champion champion) {
		champion.baseAttackDamage -= plusAttack;
		champion.updateStats ();
	}


}
