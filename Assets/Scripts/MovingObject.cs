using UnityEngine;
using System.Collections;

public abstract class MovingObject : MonoBehaviour {

	protected bool isDragon;

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;
	private LayerMask collisionLayer;

	public Vector3 groundCheck;
	public Vector3 hitCheck;
	private bool grounded = false;
	//private bool jump = true;
	private bool facingRight = true;
	private Animator anim;

	private float moveForce = 365f;
	private float maxSpeed = 5f;
	private float jumpForce = 500f;

	// Use this for initialization
	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		collisionLayer = LayerMask.GetMask ("Collision Layer");
	}

	protected void MoveObject<T>(float moveXDir){
		bool canMove;
		RaycastHit2D hit;
		int hitDirX;

		if (facingRight) {
			hitDirX = (int)moveXDir + 5;
		} else {
			hitDirX = (int)moveXDir - 5;
		}


		if (moveXDir > 0 && !facingRight) {
			Flip ();
		} else if (moveXDir < 0 && facingRight) {
			Flip ();
		}

		canMove = CanObjectMove(hitDirX, 0, out hit);

		if (canMove) {
			
			if (moveXDir * rigidBody.velocity.x < maxSpeed) {
				rigidBody.AddForce (Vector2.right * moveXDir * moveForce);
			}
			if (Mathf.Abs (rigidBody.velocity.x) > maxSpeed) {
				rigidBody.velocity = new Vector2 (Mathf.Sign (rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
			}
			return;
		}
		
		T hitComponent = hit.transform.GetComponent<T>();

	}

	protected void Jump(){

		if (grounded) {
			Debug.Log ("Jump! " + jumpForce);
			//For once you add a jump animation:
			//anim.setTrigger("Jump");
			rigidBody.AddForce(new Vector2(0f, jumpForce));

		} else {
			Debug.Log ("Cant Jump!");
		}
	}

	protected void Attack(int damage){
		Debug.Log ("Attack!");
		anim.SetTrigger ("Attack");
	}

	protected void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	protected bool CanObjectMove(int xDirection, int yDirection, out RaycastHit2D hit){
		Vector2 startPosition = rigidBody.position;
		Vector2 endPosition = startPosition + new Vector2 (xDirection, yDirection);
		
		boxCollider.enabled = false;
			hit = Physics2D.Linecast (startPosition, endPosition, collisionLayer);
		
		boxCollider.enabled = true;
		
		if (hit.transform == null) {
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
	
}
