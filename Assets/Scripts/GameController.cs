using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController Instance;

	void Awake () {

		if (Instance != null && Instance != this) {
			DestroyImmediate(gameObject);
		}

		Instance = this;
		DontDestroyOnLoad (gameObject);
	
	}

	void Update () {
	
	}
}
