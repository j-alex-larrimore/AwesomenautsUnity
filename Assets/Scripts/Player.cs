using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	private Animator animator;

	protected override void Start(){
		base.Start ();
		animator = GetComponent<Animator> ();
	}

	void Update () {
		base.Update ();
		if (Input.GetKeyDown ("space")) {
			Jump ();
		}

		if (Input.GetKeyDown ("q")) {
			animator.SetTrigger ("playerAttack");
			Attack (1);
		}
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		if (h != 0) {
			animator.SetTrigger ("playerWalk");
			MoveObject<EnemyCreep> (h);
		} else {
			animator.SetTrigger("playerIdle");
		}
	}

	protected override void HandleCollision<T>(T component){

	}

		/*//public float speed = 6.0F;
		//public float jumpSpeed = 8.0F;
		//public float gravity = 20.0F;
		//private Vector3 moveDirection = Vector3.zero;
		
		void Update() {
			//CharacterController controller = GetComponent<CharacterController>();
			//if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//if (Input.GetButton("Jump"))
			//	moveDirection.y = jumpSpeed;
			
			//}
			//moveDirection.y -= gravity * Time.deltaTime;
			controller.Move(moveDirection * Time.deltaTime);
		}*/


}
