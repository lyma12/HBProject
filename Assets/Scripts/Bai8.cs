using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bai8 : MonoBehaviour
{
    [SerializeField]
    private Transform startMarker;
    [SerializeField]
    private Transform endMarker;
    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    private float timeMoveAndStop;
    private bool isMoving = false;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        timeMoveAndStop = 1;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Move to the target end position.
    void Update()
    {
        if(Vector3.Distance(transform.position, endMarker.position) < 0.1f){
            var tmp = startMarker;
            startMarker = endMarker;
            endMarker = tmp;
            startTime = Time.time;
        }else{
            if(timeMoveAndStop > 0){
            if(isMoving){
                // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
            }
            timeMoveAndStop -= Time.deltaTime;
        }
        else{
            timeMoveAndStop = 1;
            isMoving = !isMoving;
            if(!isMoving){
                startTime += 1;
            }
        }
        }
    }
}
