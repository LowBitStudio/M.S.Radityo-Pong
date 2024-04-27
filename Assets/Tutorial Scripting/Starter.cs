using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Starter : MonoBehaviour
{
   string[] HoloMyth = 
   { 
    "Watson Amelia", 
    "Gawr Gura", 
    "Calliope Mori", 
    "Takanashi Kiara", 
    "Ninomae Ina'nis"
    };

    private void Start()
    {
        /*for (int i = 0; i < HoloMyth.Length; i++){
            Debug.Log("I love " + HoloMyth[i]);
        }*/

        foreach (var HoloElement in HoloMyth){
            Debug.Log("I love " + HoloElement);
        }
    }
}
