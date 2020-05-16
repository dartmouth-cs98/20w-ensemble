using UnityEngine;
using WebSocketSharp;
using System.Collections;
using System.Collections.Generic;
using System;

public class WebSocketComm : MonoBehaviour
{
    private WebSocket webSocket;
    public AccompanimentPlayer AP;

    public void Start()
    {
        StartCoroutine(ConnectToWebSocket());
    }

    public void Update(){
        if (Input.GetKeyDown("space"))
        {
            StartCoroutine(SendHello());
        }
    }

    private IEnumerator SendHello(){
        webSocket.Send("hello from Unity");
        yield return new WaitForSeconds(0.05f);
    }

    private IEnumerator ConnectToWebSocket()
    {
        webSocket = new WebSocket("ws://47.232.172.110:4000");
        webSocket.OnMessage += (sender, e) => InterpretMessage(e.Data);

        webSocket.Connect();

        webSocket.Send("hello from Unity");
        yield return new WaitForSeconds(0.05f);
    }

    private void OnDestroy()
    {
        webSocket.Close();
    }

    private void InterpretMessage(string data)
    {
        string instrument = data.Substring(0, data.Length - 3);
        string midi = data.Substring(data.Length - 3);
        if(String.Compare(midi, "off") == 0)
        {
          AP.StopNote(instrument);
        } else
        {
          int midiOut = 0;
          if(Int32.TryParse(midi, out midiOut))
          {
            AP.PlayNote(midiOut, instrument);
          }
        }
        Debug.Log(data);
    }
}
