using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]

public struct Gesture{

    public string name;
    public List<Vector3> fingerDatas;
    public UnityEvent onRecognized;
}



public class GestureDetector : MonoBehaviour
{
    public OVRSkeleton skeleton;
    private List<OVRBone> fingerBones;
    public List<Gesture> gestures;
    public bool debugMode = true;

    // Start is called before the first frame update
    void Start()
    {
        fingerBones=new List<OVRBone>(skeleton.Bones);
    }

    // Update is called once per frame
    void Update()
    {
        if(debugMode && Input.GetKeyDown(KeyCode.Space)){
            Save();
        }
    }

    void Save(){
        Gesture g = new Gesture();
        g.name = "New Gesture";
        List<Vector3> data = new List<Vector3>();
        foreach (var bone in fingerBones)
        {
            //finger position relative to root
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }
        g.fingerDatas=data;
        gestures.Add(g);
    }
}
