﻿using UnityEngine;
using System.Collections;

public class EnemyBase : Base {

	private bool broken = false;
	private Animator animator;

	// Use this for initialization
	void Start () {
		SetHealth (2);
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (CheckIfBroken() && !broken) {
			broken = true;
			animator.SetTrigger("buildingDead");
		} 
	}
}
