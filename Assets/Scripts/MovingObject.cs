using UnityEngine;
using System.Collections;

public class MovingObject : MonoBehaviour {

	private BoxCollider2D boxCollider;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	protected virtual void Start () {
		boxCollider = GetComponent<BoxCollider2D> ();
		rigidBody = GetComponent<Rigidbody2D> ();
	}
	
	protected bool MoveObject(int xDirection){
		Vector2 startPosition = rigidBody.position;
		Vector2 endPosition = startPosition + new Vector2 (xDirection, 0);

		StartCoroutine (SmoothMovementRoutine (endPosition));
		//rigidBody.MovePosition (endPosition);

		return true;
	}

	protected IEnumerator SmoothMovementRoutine(Vector2 endPosition){
		float remainingDistanceToEndPosition;

		do{
			remainingDistanceToEndPosition = (rigidBody.position - endPosition).sqrMagnitude;
			Vector2 updatedPosition = Vector2.MoveTowards(rigidBody.position, endPosition, 25f * Time.deltaTime);
			rigidBody.MovePosition(updatedPosition);
			//Debug.Log ("Start: " + endPosition + " End: " + updatedPosition + " Remaining: " + remainingDistanceToEndPosition + " Goal: " + float.Epsilon);
			yield return null;
		}while(remainingDistanceToEndPosition > 0.05);
	}

	protected void Jump(){

	}

	// Update is called once per frame
	void Update () {
	
	}
	
}
