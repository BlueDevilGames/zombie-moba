﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Unit : MonoBehaviour {

	public int baseHealth;
	public int healthPerLevel;
	public int baseArmor;
	public int armorPerLevel;
	public int team;
	public int baseHealthRegen;
	public int healthRegenPerLevel;
	public int baseAttackDamage;
	public int attackDamagePerLevel;

	protected int curHealth;
	protected int curArmor;
	protected int curHealthRegen;
	protected int curAttackDamage;
	protected int level;
	protected List<Unit> unitsInRange;


	// Use this for initialization
	public virtual void Start () {
		level = 1;
		updateStats ();
		unitsInRange = new List<Unit> ();
//		Debug.Log(curHealth + " " + curArmor + " " + curHealthRegen + " " + curAttackDamage);
	}
	
	// Update is called once per frame
	public virtual void Update () {
		CheckIfDead ();
		Regen ();

	}

	public void TakeDamage(int unmodifiedDamage) {

		curHealth -= unmodifiedDamage * (1 - (curArmor / (curArmor + 100)));

	}

	void CheckIfDead() {
		if(curHealth <= 0) {
			Destroy(this.gameObject); //need animations instead later
		}
	}

	void Regen() {
		curHealth += curHealthRegen;
	}

	void LevelUp() {
		level++;
		updateStats ();
	}

	void updateStats() {
		curArmor = baseArmor + (armorPerLevel * level);
		curHealth = baseHealth + (healthPerLevel * level);
		curHealthRegen = baseHealthRegen + (healthRegenPerLevel * level);
		curAttackDamage = baseAttackDamage + (attackDamagePerLevel * level);
	}

	public bool isDead() {
		return curHealth < 0;
	}

	public Unit GetClosestUnit() {
		unitsInRange.RemoveAll (item => item == null);
		float dist = float.MaxValue;
		Unit closestUnit = null;
		foreach (Unit unit in unitsInRange) {
			float distToUnit = Vector3.Distance(GetComponentInParent<Transform>().position, unit.GetComponentInParent<Transform>().position);
			if(distToUnit < dist) {
				closestUnit = unit;
			}
		}
		return closestUnit;
	}

	protected void attack(Unit unit) {

	}

}
