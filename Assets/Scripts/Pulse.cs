using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    //private float timePassed = Time.time;

    void Update ()
    { 
        transform.localScale = Vector3.one * (((Mathf.Sin(Time.time * 4) + 4) * 0.15f) + 0.25f) ;
        Debug.Log(Time.time);
        //while (this.currentRatio != this.growthBound)
        //{
        //    currentRatio = Mathf.MoveTowards(currentRatio, growthBound, 0.02f);

        //    transform.localScale = Vector3.one * currentRatio; 
        //}

        //while (this.currentRatio != this.shrinkBound)
        //{
        //    currentRatio = Mathf.MoveTowards(currentRatio, shrinkBound, 0.02f);

        //    transform.localScale = Vector3.one * currentRatio;  
        //}
    }
}
