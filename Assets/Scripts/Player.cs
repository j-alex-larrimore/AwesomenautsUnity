using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	private bool attacking = false;
	private Animator animator;
	public int health = 5;
	private float attackTimer = 0f;
	public float attackDelayTime = 2.0f;
	public float respawnDelayTimer = 5.0f;
	private float respawnTimer = 0f;
	private bool isDead = false;

	protected override void Start(){
		base.Start ();
		animator = GetComponent<Animator> ();
	}

	void Update () {
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
		if (health <= 0) {
			Debug.Log ("OUCH! " + health);
			Respawn();
		}
	}

	public void Respawn(){
		isDead = true;
		//Make the character wait 2 seconds and appear in top left of screen
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
