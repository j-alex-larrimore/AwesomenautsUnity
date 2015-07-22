using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	public Transform pBase;
	public Transform eBase;
	public Transform eCreep;
	public Transform player;

	private Player playerRef;
	private EnemyBase eBaseRef;
	private PlayerBase pBaseRef;

	private float creepTimer = 0f;
	public float creepSpawnTime = 10.0f;
	
	public float respawnDelayTimer = 5.0f;
	private float respawnTimer = 0f;

	void Awake () {

		if (Instance != null && Instance != this) {
			DestroyImmediate(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
	
		SetupLevel ();
		
		playerRef = GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Player> ();
		pBaseRef = GameObject.FindGameObjectWithTag ("PlayerBase").transform.GetComponent<PlayerBase> ();
		eBaseRef = GameObject.FindGameObjectWithTag ("EnemyBase").transform.GetComponent<EnemyBase> ();
	}

	void Update () {
		creepTimer += Time.deltaTime;
		
		if (creepTimer >= creepSpawnTime)
		{
			Instantiate (eCreep, new Vector3 (14f, -12f, 0f), Quaternion.identity );
			// reset timer
			creepTimer = 0;
		}

		if (playerRef.isDead) {
			respawnTimer += Time.deltaTime;
			if(respawnTimer >= respawnDelayTimer){
				respawnTimer = 0;
				playerRef.gameObject.SetActive(false);
				Instantiate (player, new Vector3 (-15f, -6f, 0f), Quaternion.identity );
				playerRef = GameObject.FindGameObjectWithTag ("Player").transform.GetComponent<Player>();
				Debug.Log ("New Player " + playerRef.health);
			}
		}
	}
	
	private void SetupLevel(){
		Instantiate (player, new Vector3 (-15f, -6f, 0f), Quaternion.identity );
		Instantiate (pBase, new Vector3 (-16.5f, -6f, 0f), Quaternion.identity );
		Instantiate (eBase, new Vector3 (19.8f, -6f, 0f), Quaternion.identity );


	
	}

	private void AddCreep(){

	}
}
