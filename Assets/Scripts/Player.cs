using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	private bool attacking = false;
	private Animator animator;
	public int health = 5;
	private float attackTimer = 0f;
	public float attackDelayTime = 2.0f;
	public bool isDead = false;

	protected override void Start(){
		base.Start ();
		animator = GetComponent<Animator> ();
	}

	protected override void Update () {
		base.Update ();
		if (!isDead) {
			attackTimer += Time.deltaTime;
			if (Input.GetKeyDown ("space")) {
				Jump ();
			}

			if (Input.GetKeyDown ("q") && attackTimer >= attackDelayTime) {
				attackTimer = 0;
				animator.SetTrigger ("playerAttack");
				this.attacking = true;
			} else {
				this.attacking = false;
			}
		}
	}

	public void LoseHealth(int damageTaken){
		health -= damageTaken;
		Debug.Log ("OUCH! " + health);
		if (health <= 0) {
			Respawn();
		}
	}

	public void Respawn(){
		isDead = true;
		DestroyImmediate (boxCollider);
		DestroyImmediate (rigidBody);
	}

	void FixedUpdate(){
		if (!isDead) {
			float h = Input.GetAxis ("Horizontal");

			CheckCollisions<EnemyCreep> ();

			if (h != 0) {
				animator.SetTrigger ("playerWalk");
				MoveObject (h);
			} else {
				animator.SetTrigger ("playerIdle");
			}
		}
	}

	protected override void HandleCollision<T>(T component){
		EnemyCreep eCreep = component as EnemyCreep;
		if (this.attacking) {
			Debug.Log ("Actually attack");
			eCreep.LoseHealth (1);
		}
	}


}
