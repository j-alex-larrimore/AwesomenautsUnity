using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	public GameObject[] creeps;
	public GameObject[] heroes;
	public GameObject[] bases;

	private EnemyBase eBase;
	private GameObject pBase1;

	private Transform pBase;

	void Awake () {

		if (Instance != null && Instance != this) {
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
	
		SetupLevel ();
	}

	void Update () {
	
	}

	private void SetupLevel(){
		pBase = new GameObject ("Player Base").transform;
	
		pBase1 = (GameObject)Instantiate (bases [1], new Vector3 (0, 0, 0f), Quaternion.identity );
		pBase1.transform.SetParent (pBase); 

	}

	private void AddCreep(){

	}
}
