using UnityEngine;
using System.Collections;

public class EnemyCreep : MovingObject {

	private Animator animator;

	protected override void Start(){
		base.Start ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//for jumping if ever implemented
		base.Update ();

		MoveObject (-5f);
	}
}
