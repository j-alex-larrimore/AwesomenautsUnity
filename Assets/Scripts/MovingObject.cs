using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	protected bool isDragon;
	protected bool canMove;

	private RaycastHit2D hitObject;

	protected BoxCollider2D boxCollider;
	protected Rigidbody2D rigidBody;
	private LayerMask collisionLayer;

	public Vector3 groundCheck;
	public Vector3 hitCheck;
	private bool grounded = false;
	//private bool jump = true;
	private bool facingRight = true;
	private Animator anim;

	protected float moveForce = 365f;
	protected float maxSpeed = 5f;
	protected float jumpForce = 500f;

	// Use this for initialization
	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		collisionLayer = LayerMask.GetMask ("Collision Layer");
	}

	protected void MoveObject(float moveXDir){
		if (!isDragon) {
			if (moveXDir > 0 && !facingRight) {
				Flip ();
			} else if (moveXDir < 0 && facingRight) {
				Flip ();
			}
		} else {
			if (moveXDir > 0 && !facingRight) {
				facingRight = !facingRight;
			} else if (moveXDir < 0 && facingRight) {
				facingRight = !facingRight;
			}
		}

		if (canMove) {
			
			if (moveXDir * rigidBody.velocity.x < maxSpeed) {
				rigidBody.AddForce (Vector2.right * moveXDir * moveForce);
			}
			if (Mathf.Abs (rigidBody.velocity.x) >= maxSpeed) {
				rigidBody.velocity = new Vector2 (Mathf.Sign (rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
			}
			return;
		}
	}

	protected void CheckCollisionType<T>(){
		if (!canMove) {
			T hitComponent = hitObject.transform.GetComponent<T> ();
			if (hitComponent != null) {
				Debug.Log (hitComponent.GetType());
				if(hitComponent.GetType().ToString() == "PlayerBase" || hitComponent.GetType().ToString() == "EnemyBase"){
					HandleBaseCollision(hitComponent);
				}else{
					HandleCollision (hitComponent);
				}
			}
		}
	}

	protected void CheckCollisions(){
		int hitDirX;
		
		if (facingRight) {
			hitDirX =  3;
		} else {
			hitDirX = - 3;
		}
		
		canMove = CanObjectMove(hitDirX, 0);
	}

	protected void Jump(){
		if (grounded || canMove == false) {
			Debug.Log ("Jump! " + jumpForce);
			//For once you add a jump animation:
			//anim.setTrigger("Jump");
			rigidBody.AddForce(new Vector2(0f, jumpForce));

		} else {
			Debug.Log ("Cant Jump!");
		}
	}

	protected void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	protected bool CanObjectMove(int xDirection, int yDirection){
		Vector2 startPosition = rigidBody.position;
		Vector2 endPosition = startPosition + new Vector2 (xDirection, yDirection);
		
		boxCollider.enabled = false;
			hitObject = Physics2D.Linecast (startPosition, endPosition, collisionLayer);
		
		boxCollider.enabled = true;
		
		if (hitObject.transform == null) {
			return true;
		}
		return false;

	}

	protected virtual void Update () {
		groundCheck = transform.position;
		groundCheck.y -= 3; 
		grounded = Physics2D.Linecast (transform.position, groundCheck, 1 << LayerMask.NameToLayer ("Ground"));

	}

	protected abstract void HandleCollision<T>(T component);

	protected abstract void HandleBaseCollision<T>(T component);
	
}
