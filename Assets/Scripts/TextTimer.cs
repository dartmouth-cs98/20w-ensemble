 using UnityEngine;
 using System.Collections;
 
 public class TextTimer : MonoBehaviour
 {
     
     public float time = 20; //Seconds to read the text
 
     IEnumerator Start ()
     {
         yield return new WaitForSeconds(time);
         Destroy(gameObject);
     }
 }