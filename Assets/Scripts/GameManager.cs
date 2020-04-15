using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!

	public int songID = -1;

	public Vector3 currPosition = new Vector3(0,0,0);

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
