using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	protected GameManager () {} // guarantee this will be always a singleton only - can't use the constructor!

	//what song to play
	static int MAX_SONGS = 2;
	public int songID = 0;

	private Dictionary<int, string> songMap = new Dictionary<int, string>()
	{
		{0, "canonInD"},
		{1, "letItGo"},
		{2, "beethoven5"}
	};

	//position for teleportation
	public Vector3 currPosition = new Vector3(0,0,0);



	//settings
	public int numAudience = 0;
	public int numOrchestra = 0;
	public string followingType = "static";
	public string stageSize = "small";
	public bool fromFrontStage = false;

	public void FrontStageToggle()
	{
		fromFrontStage = !fromFrontStage;
	}
	public bool FromFrontStage()
	{
		return fromFrontStage;
	}

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
		followingType = "follow";
	}
	public void FollowingOptionNone()
	{
		followingType = "static";
	}
	public void SmallStage()
	{
		stageSize = "small";
	}
	public void LargeStage()
	{
		stageSize = "large";
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
	public string GetStage()
	{
		return stageSize;
	}

	//song choice
	public void IncreaseSongID()
	{
		if(songID < MAX_SONGS)
		{
			songID += 1;
		}
	}
	public void DecreaseSongID()
	{
		if(songID > 0)
		{
			songID -= 1;
		}
	}
	public int GetSong()
	{
		return songID;
	}
	public string GetSongName()
	{
		return songMap[songID];
	}

	//persistence
	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
