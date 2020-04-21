using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVariables : MonoBehaviour
{
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
}
