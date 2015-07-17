using UnityEngine;
using System.Collections;

public class Player : MovingObject {

	void Update () {
		int xAxis = 0;

		xAxis = (int)Input.GetAxisRaw ("Horizontal");
		MoveObject (xAxis);

		if (Input.GetKeyDown ("space")) {
			Jump();
		}
	}


}
