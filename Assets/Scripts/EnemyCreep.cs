using UnityEngine;
using System.Collections;

public class EnemyCreep : MovingObject {

	private Animator animator;

	protected override void Start(){
		base.Start ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//for jumping if ever implemented
		base.Update ();
		animator.SetTrigger ("creepWalk");
		MoveObject (-3f);
		Flip ();
	}

	private void Attack(int damage){
		animator.SetTrigger ("creepAttack");
	}
}
