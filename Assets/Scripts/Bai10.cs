using System.Collections;
using UnityEngine;

public class Bai10: MonoBehaviour
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
    private bool isWaiting = false;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;
        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    IEnumerator WaitForRandomSeconds(){
        float randomTime = Random.Range(1.0f, 2.0f);
        isWaiting = true;
        yield return new WaitForSeconds(randomTime);
        var tmp = startMarker;
            startMarker = endMarker;
            endMarker = tmp;
            startTime = Time.time;
        isWaiting = false;
    }
    // Move to the target end position.
    void Update()
    {
        if(Vector3.Distance(transform.position, endMarker.position) < 0.1f){
            if(!isWaiting) StartCoroutine(WaitForRandomSeconds());
        }else{
                // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }
    }
}
