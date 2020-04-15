using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstageManager : MonoBehaviour
{
    protected BackstageManager () {} // guarantee this will be always a singleton only - can't use the constructor!

	public Vector3 currPosition = new Vector3(0,0,0);

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
