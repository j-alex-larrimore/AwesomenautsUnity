using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;

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
		if (Mathf.Abs (moveXDir * rigidBody.velocity.x) < maxSpeed) {
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

	protected virtual void Update () {
		groundCheck = transform.position;
		groundCheck.y -= 3; 
		grounded = Physics2D.Linecast (transform.position, groundCheck, 1 << LayerMask.NameToLayer ("Ground"));

	}
	
}
