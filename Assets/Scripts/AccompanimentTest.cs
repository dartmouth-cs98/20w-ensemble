using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AccompanimentTest : MonoBehaviour
{
    public AccompanimentPlayer AP;
    private int vioMidi = 55;
    private int celloMidi = 36;
    private bool vpushed = false;
    private bool cpushed = false;

    // Start is called before the first frame update
    public void TestViolinPlayback()
    {
      if(!vpushed)
      {
        AP.NoteOn(vioMidi, 1.0f, "violin");
        vioMidi = vioMidi + 10;
        vpushed = true;
      }
      else
      {
        AP.NoteOff("violin");
        vpushed = false;
      }
    }

    public void TestCelloPlayback()
    {
      if(!cpushed)
      {
        AP.NoteOn(celloMidi, 1.0f, "cello");
        celloMidi = celloMidi + 10;
        cpushed = true;
      }
      else
      {
        AP.NoteOff("cello");
        cpushed = false;
      }
    }
}
