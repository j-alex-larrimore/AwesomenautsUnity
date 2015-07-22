using UnityEngine;
using System.Collections;

public class EnemyCreep : MovingObject {

	private Animator animator;
	public int health = 2;
	private bool attacking = false;
	private float attackTimer = 0f;
	public float attackDelayTime = 2.0f;

	protected override void Start(){
		base.Start ();
		isDragon = true;
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	protected override void Update () {
		attackTimer += Time.deltaTime;
		//for jumping if ever implemented
		base.Update ();
		animator.SetTrigger ("creepWalk");

	}

	public void LoseHealth(int damageTaken){
		health -= damageTaken;
		Debug.Log ("current: " + health);
		if (health <= 0) {
			gameObject.SetActive(false);
		}
	}

	void FixedUpdate(){
		CheckCollisions();
		CheckCollisionType<Player>();
		CheckCollisionType<PlayerBase>();
		MoveObject(-0.6f);
	}

	private void Attack(){
		animator.SetTrigger ("creepAttack");
		this.attacking = true;
	}

	protected override void HandleCollision<T>(T component){
		if (attackTimer >= attackDelayTime) {
			attackTimer = 0;
			Attack ();
		} else {
			this.attacking = false;
		}

		Player player = component as Player;
		if (this.attacking) {
			player.LoseHealth (1);
		}
	}

	protected override void HandleBaseCollision<T>(T component){
		Debug.Log ("Base Collide");
		if (attackTimer >= attackDelayTime) {
			attackTimer = 0;
			Attack ();
		} else {
			this.attacking = false;
		}
		
		PlayerBase pbase = component as PlayerBase;
		if (this.attacking) {
			pbase.LoseHealth (1);
		}
	}
}
