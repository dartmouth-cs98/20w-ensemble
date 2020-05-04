﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!

	//what song to play
	public int songID = -1;

	//position for teleportation
	public Vector3 currPosition = new Vector3(0,0,0);

	//settings
	public int numAudience = 0;
	public int numOrchestra = 0;
	public string followingType = "score";
	public void AudienceOptionUp()
	{
		if(numAudience < 8)
		{
			numAudience += 1;
		}
	}
	public void OrchestraOptionUp()
	{
		if(numOrchestra < 8)
		{
			numOrchestra += 1;
		}
	}
	public void AudienceOptionDown()
	{
		if(numAudience > 0)
		{
			numAudience -= 1;
		}
	}
	public void OrchestraOptionDown()
	{
		if(numOrchestra > 0)
		{
			numOrchestra -= 1;
		}
	}
	public void FollowingOptionScore()
	{
		followingType = "score";
	}
	public void FollowingOptionTempo()
	{
		followingType = "tempo";
	}
	public void FollowingOptionNone()
	{
		followingType = "static";
	}
	public string GetFollowing()
	{
		return followingType;
	}
	public int GetAudience()
	{
		return numAudience;
	}
	public int GetOrchestra()
	{
		return numOrchestra;
	}

	//persistence function
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
