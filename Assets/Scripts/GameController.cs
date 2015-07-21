using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	//public GameObject[] creeps;
	//public GameObject[] heroes;
	//public GameObject[] bases;

	//private GameObject eBase1;
	//private GameObject pBase1;

	public Transform pBase;
	public Transform eBase;
	public Transform eCreep;

	private float creepTimer = 0f;
	public float creepSpawnTime = 10.0f;

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
		creepTimer += Time.deltaTime;
		
		if (creepTimer >= creepSpawnTime)
		{
			Debug.Log("Creep!");

			//Transform eCreep = new GameObject("Dragon").transform;
			//GameObject eCreep1 = (GameObject)Instantiate (creeps [0], new Vector3 (16f, -6f, 0f), Quaternion.identity );
			//eCreep1.transform.SetParent (eCreep); 
			Instantiate (eCreep, new Vector3 (14f, -8f, 0f), Quaternion.identity );
			// reset timer
			creepTimer = 0;
		}
	}
	
	private void SetupLevel(){
		//pBase = new GameObject ("Player Base").transform;
		//eBase = new GameObject ("Enemy Base").transform;

	
		//pBase1 = (GameObject)Instantiate (bases [1], new Vector3 (-16.5f, -6f, 0f), Quaternion.identity );
		Instantiate (pBase, new Vector3 (-16.5f, -6f, 0f), Quaternion.identity );
		Instantiate (eBase, new Vector3 (19.8f, -6f, 0f), Quaternion.identity );
		//pBase1.transform.SetParent (pBase); 

		//eBase1 = (GameObject)Instantiate (bases [0], new Vector3 (19.8f, -6f, 0f), Quaternion.identity );
		//eBase1.transform.SetParent(eBase); 

	}

	private void AddCreep(){

	}
}
