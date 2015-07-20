using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;

	//private int speed = 5;
	//public float speed = 6f;
	//public float jumpSpeed = 80f;
	//public float gravity = 10f;

	public Vector3 groundCheck;
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
	}

	protected bool MoveObject(float moveXDir){
		/*Vector2 startPosition = rigidBody.position;
		moveXDir *= (speed / 10);
		//float moveYDir = -(gravity/40);
		float moveYDir = 0;
		Vector2 endPosition = startPosition + new Vector2 (moveXDir, moveYDir);
		rigidBody.MovePosition (endPosition);*/

		if (moveXDir * rigidBody.velocity.x < maxSpeed) {
			rigidBody.AddForce (Vector2.right * moveXDir * moveForce);
		}
		if (Mathf.Abs (rigidBody.velocity.x) > maxSpeed) {
			rigidBody.velocity = new Vector2 (Mathf.Sign (rigidBody.velocity.x) * maxSpeed, rigidBody.velocity.y);
		}

		if (moveXDir > 0 && !facingRight) {
			Flip ();
		} else if (moveXDir < 0 && facingRight) {
			Flip ();
		}

		return true;
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

	protected void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Update is called once per frame
	protected virtual void Update () {
		groundCheck = transform.position;
		groundCheck.y -= 3; 
		grounded = Physics2D.Linecast (transform.position, groundCheck, 1 << LayerMask.NameToLayer ("Ground"));

	}


	
}
