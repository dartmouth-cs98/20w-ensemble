using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AccompanimentTest : MonoBehaviour
{
    public AccompanimentPlayer AP;
    private int vioMidi = 55;
    private int celloMidi = 36;

    // Start is called before the first frame update
    public void TestViolinPlayback()
    {
      AP.PlayNote(vioMidi, 1.0f, "violin");
      vioMidi = vioMidi + 10;
    }

    public void TestCelloPlayback()
    {
      AP.PlayNote(celloMidi, 1.0f, "cello");
      celloMidi = celloMidi + 10;
    }
}
