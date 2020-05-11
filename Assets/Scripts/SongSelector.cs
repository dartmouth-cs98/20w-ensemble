using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongSelector : MonoBehaviour
{
    public TMP_Text songDisplay;
    GameManager statVar;


    private Dictionary<int, string> songMap = new Dictionary<int, string>()
    {
      {0, "Pachelbel's Canon"},
      {1, "Let It Go"},
      {2, "Beethoven's 5th Symphony"}
    };

    // Start is called before the first frame update
    void Start()
    {
        statVar = UnityEngine.Object.FindObjectOfType<GameManager>();
        songDisplay.text = songMap[statVar.GetSong()];
    }

    public void incSong()
    {
      statVar.IncreaseSongID();
      songDisplay.text = songMap[statVar.GetSong()];
    }
    public void decSong()
    {
      statVar.DecreaseSongID();
      songDisplay.text = songMap[statVar.GetSong()];
    }
}
