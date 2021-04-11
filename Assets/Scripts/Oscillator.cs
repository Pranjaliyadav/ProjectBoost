using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeReference] Vector3 movementVector;
    float movementfactor;     //this will create a range slider in unity components for range bw 0 nd 1
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;               //to get current postion
        
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){
            return;
        }
        else{
            float cycles = Time.time / period;      //continually growing over time       

            const float Tau = Mathf.PI * 2;           //2PI is total time for one wave , const val of 6.283
            float rawSineWave = Mathf.Sin(cycles * Tau);            //going from -1 to 1

            movementfactor = (rawSineWave + 1f) / 2f;          //recalculated to go from 0 to 1 so its cleaner
        
            Vector3 offset = movementVector * movementfactor;
            transform.position = startingPosition + offset;
        }
    }
}
