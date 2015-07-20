using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	public GameObject[] creeps;
	public GameObject[] heroes;
	public GameObject[] bases;

	private GameObject eBase1;
	private GameObject pBase1;

	private Transform pBase;
	private Transform eBase;

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
		eBase = new GameObject ("Enemy Base").transform;
	
		pBase1 = (GameObject)Instantiate (bases [1], new Vector3 (-16.5f, -6f, 0f), Quaternion.identity );
		pBase1.transform.SetParent (pBase); 

		eBase1 = (GameObject)Instantiate (bases [0], new Vector3 (19.8f, -6f, 0f), Quaternion.identity );
		eBase1.transform.SetParent(eBase); 

	}

	private void AddCreep(){

	}
}
