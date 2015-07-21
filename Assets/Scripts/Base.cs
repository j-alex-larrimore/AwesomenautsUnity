using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {

	public int health;

	// Use this for initialization
	void Start () {
	
	}

	protected void SetHealth(int startHealth){
		health = startHealth;
	}

	protected void LoseHealth(int damageTaken){
		health -= damageTaken;
	}

	protected bool CheckIfBroken(){
		if (health <= 0) {
			return true;
		} else {
			return false;
		}
	}
}
