using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    Color32[] colors = new Color32[6];



    void Start()
    {
        

        colors[0] = new Color32(23, 195, 197, 255);
        colors[1] = new Color32(66, 131, 195, 255);
        colors[2] = new Color32(229, 90, 119, 255);
        colors[3] = new Color32(170, 102, 185, 255);
        colors[4] = new Color32(246, 184, 83, 255);
        colors[5] = new Color32(160, 209, 102, 255);

        int randomColor = Random.Range(0, colors.Length);


        

        foreach (MeshRenderer r in GetComponentsInChildren<MeshRenderer>())
        {


              r.material.color = colors[randomColor];
          
           

        }
    }

}

