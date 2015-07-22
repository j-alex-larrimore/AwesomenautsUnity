using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	public PlayerBase pBase;
	public EnemyBase eBase;
	public Transform eCreep;

	public Player player;

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
			Instantiate (eCreep, new Vector3 (14f, -8f, 0f), Quaternion.identity );
			// reset timer
			creepTimer = 0;
		}

	}
	
	private void SetupLevel(){
		Instantiate (player.transform, new Vector3 (-15f, -6f, 0f), Quaternion.identity );
		Instantiate (pBase.transform, new Vector3 (-16.5f, -6f, 0f), Quaternion.identity );
		Instantiate (eBase.transform, new Vector3 (19.8f, -6f, 0f), Quaternion.identity );

	}

	private void AddCreep(){

	}
}
