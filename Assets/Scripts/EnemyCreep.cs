using UnityEngine;
using System.Collections;

public class EnemyCreep : MovingObject {

	private Animator animator;

	protected override void Start(){
		base.Start ();
		isDragon = true;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//for jumping if ever implemented
		base.Update ();
		animator.SetTrigger ("creepWalk");
	}

	void FixedUpdate(){
		MoveObject<Player> (-0.8f);
	}

	private void Attack(int damage){
		animator.SetTrigger ("creepAttack");
	}

	protected override void HandleCollision<T>(T Component){

	}
}
