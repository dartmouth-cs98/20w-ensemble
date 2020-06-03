using UnityEngine;
using WebSocketSharp;
using System.Collections;
using System.Collections.Generic;
using System;

public class WebSocketComm : MonoBehaviour
{
    GameManager gm;
    private WebSocket webSocket;
    public AccompanimentPlayer AP;

    [System.Serializable]
    public class AccompData
    {
        public string type;
        public Accompaniment data;

        public static AccompData CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<AccompData>(jsonString);
        }
    }
    [System.Serializable]
    public class Accompaniment
    {
      public string inst0;
      public string inst1;
      public string inst2;
      public string inst3;
    }

    [System.Serializable]
    public class SongMessage
    {
      public string type;
      public SongName data;
      public SongMessage(string type, SongName data)
      {
        this.type = type;
        this.data = data;
      }
      public string FormatJson()
      {
        return JsonUtility.ToJson(this);
      }
    }
    [System.Serializable]
    public class SongName
    {
      public string song_name;
      public int tempo;
      public SongName(string song_name, int tempo)
      {
        this.song_name = song_name;
        this.tempo = tempo;
      }
    }
    [System.Serializable]
    public class StartMessage
    {
      public string type;
      public StartWord data;
      public StartMessage(string type, StartWord data)
      {
        this.type = type;
        this.data = data;
      }
      public string FormatJson()
      {
        return JsonUtility.ToJson(this);
      }
    }
    [System.Serializable]
    public class StartWord
    {
      public string msg;
      public StartWord(string msg)
      {
        this.msg = msg;
      }
    }

    private Queue<string> msgQueue = new Queue<string>();

    public void Start()
    {
        gm = UnityEngine.Object.FindObjectOfType<GameManager>();
        StartCoroutine(ConnectToWebSocket(gm.GetIP()));
        SongSelection();
    }

    public void Update(){
      if(msgQueue.Count > 0){
        HandleMessage(msgQueue.Dequeue());
      }
    }

    public void StartFollowing(){
      StartWord word = new StartWord("Start");
      StartMessage msg = new StartMessage("start_message", word);
      StartCoroutine(SendHello(msg.FormatJson()));
    }
    public void SongSelection(){
      SongName name = new SongName(gm.GetSongName(), gm.GetTempo());
      SongMessage msg = new SongMessage("song_selection", name);
      StartCoroutine(SendHello(msg.FormatJson()));
    }


    private IEnumerator SendHello(string msg){
        webSocket.Send(msg);
        yield return new WaitForSeconds(0.05f);
    }

    private IEnumerator ConnectToWebSocket(string ip)
    {
        string address = "ws://" + ip + ":4000";
        webSocket = new WebSocket(address);
        webSocket.OnMessage += (sender, e) => InterpretMessage(e.Data);

        webSocket.Connect();

        webSocket.Send("hello from unity");
        yield return new WaitForSeconds(0.05f);
    }

    private void OnDestroy()
    {
        webSocket.Close();
    }

    private void InterpretMessage(string msg)
    {
        if(msg.Contains("ccompaniment"))
        {
          if(msgQueue.Count < 1)
          {
            msgQueue.Enqueue(msg);
            Debug.Log("enqueue msg");
          }

        }
    }
    private void HandleMessage(string msg)
    {
      Debug.Log("Handle msg");
      AccompData accompData = AccompData.CreateFromJSON(msg);
      Debug.Log(accompData.data.inst3);
      int midi3 = 0;
      if(Int32.TryParse(accompData.data.inst3, out midi3)){
        Debug.Log(midi3);
        if(midi3 < 0)
        {
          AP.StopNote(3);
          //Debug.Log("stopping3");
        } else
        {
          AP.PlayNote(midi3, 3);
        }
      }
      int midi0 = 0;
      if(Int32.TryParse(accompData.data.inst0, out midi0)){
        if(midi0 < 0)
        {
          AP.StopNote(0);
          //Debug.Log("stopping0");
        } else
        {
          Debug.Log("playing0");
          AP.PlayNote(midi0, 0);
        }
      }
      int midi1 = 0;
      if(Int32.TryParse(accompData.data.inst1, out midi1)){
        if(midi1 < 0)
        {
          AP.StopNote(1);
          //Debug.Log("stopping1");
        } else
        {
          Debug.Log("playing1");
          AP.PlayNote(midi1, 1);
        }
      }
      int midi2 = 0;
      if(Int32.TryParse(accompData.data.inst2, out midi2)){
        if(midi2 < 0)
        {
        //Debug.Log("stopping2");
          AP.StopNote(2);
        } else
        {
          Debug.Log("playing2");
          AP.PlayNote(midi2, 2);
        }
      }
    }
  }
