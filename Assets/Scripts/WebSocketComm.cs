using UnityEngine;
using WebSocketSharp;
using System.Collections;
using System.Collections.Generic;
using System;

public class WebSocketComm : MonoBehaviour
{
    //GameManager gm;
    private WebSocket webSocket;
    public AccompanimentPlayer AP;
    //private bool processing = false;
    //{"type": "accompaniment", "data": {"0": [-1], "1": [-1], "2": [-1], "3": [62]}}
    [System.Serializable]
    public class PlayerInfo
    {
        public string type;
        public Accompaniment data;

        public static PlayerInfo CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<PlayerInfo>(jsonString);
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

    private Queue<string> msgQueue = new Queue<string>();

    public void Start()
    {
        //gm = UnityEngine.Object.FindObjectOfType<GameManager>();
        StartCoroutine(ConnectToWebSocket());
    }

    public void Update(){
      if(msgQueue.Count == 1){
        HandleMessage(msgQueue.Dequeue());
      }
    }

    public void StartFollowing(){
      StartCoroutine(SendHello("Start"));
    }

    private IEnumerator SendHello(string msg){
        webSocket.Send(msg);
        yield return new WaitForSeconds(0.05f);
    }

    private IEnumerator ConnectToWebSocket()
    {
        webSocket = new WebSocket("ws://10.0.1.68:4000");
        webSocket.OnMessage += (sender, e) => InterpretMessage(e.Data);

        webSocket.Connect();

        //webSocket.Send(gm.GetSongName());
        webSocket.Send("hello from unity");
        yield return new WaitForSeconds(0.05f);
    }

    private void OnDestroy()
    {
        webSocket.Close();
    }

    private void InterpretMessage(string msg)
    {
        if(String.Compare(msg.Substring(0,1), "{") == 0)
        {
          if(msgQueue.Count == 0)
          {
            msgQueue.Enqueue(msg);
            Debug.Log("enqueue msg");
          }

        }
    }
    private void HandleMessage(string msg)
    {
      Debug.Log("Handle msg");
      PlayerInfo playInfo = PlayerInfo.CreateFromJSON(msg);
      Debug.Log(playInfo.data.inst3);
      int midi3 = 0;
      if(Int32.TryParse(playInfo.data.inst3, out midi3)){
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
      if(Int32.TryParse(playInfo.data.inst0, out midi0)){
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
      if(Int32.TryParse(playInfo.data.inst1, out midi1)){
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
      if(Int32.TryParse(playInfo.data.inst2, out midi2)){
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
