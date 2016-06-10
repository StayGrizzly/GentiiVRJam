';using UnityEngine;
using System.Collections;

public class ExampleClasss : MonoBehaviour {

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float elapsedTime;
    private float journeyLength;
    private bool isMovingForward = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        if (isMovingForward == true)
        {
            ForwardMovement();
        }

        else
        { 
            BackwardMovement();
        }
    }


    void ForwardMovement()
    {
        // Debug.Log("Moving Forward!");

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

        if (gameObject.transform.position == endMarker.position)
        {
            isMovingForward = false;
            startTime = Time.time;
            journeyLength = Vector3.Distance(endMarker.position, startMarker.position);
        }

    }

    void BackwardMovement()
    {
        // Debug.Log("Moving Back!");

        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney);

        if (gameObject.transform.position == startMarker.position)
        {
            isMovingForward = true;
            startTime = Time.time;
            journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        }
    }



}
