using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!

	//what song to play
	public int songID = -1;

	//position for teleportation
	public Vector3 currPosition = new Vector3(0,0,0);

	//settings
	static public int numAudience = 0;
	static public int numOrchestra = 0;
	static public string followingType = "score";
	public void audienceOptionUp()
	{
		if(numAudience < 8)
		{
			numAudience += 1;
		}
	}
	public void orchestraOptionUp()
	{
		if(numOrchestra < 8)
		{
			numOrchestra += 1;
		}
	}
	public void audienceOptionDown()
	{
		if(numAudience > 0)
		{
			numAudience -= 1;
		}
	}
	public void orchestraOptionDown()
	{
		if(numOrchestra > 0)
		{
			numOrchestra -= 1;
		}
	}
	public void followingOptionScore()
	{
		followingType = "score";
	}
	public void followingOptionTempo()
	{
		followingType = "tempo";
	}
	public void followingOptionNone()
	{
		followingType = "static";
	}
	public string getFollowing()
	{
		return followingType;
	}
	public int getAudience()
	{
		return numAudience;
	}
	public int getOrchestra()
	{
		return numOrchestra;
	}

	//persistence function
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
