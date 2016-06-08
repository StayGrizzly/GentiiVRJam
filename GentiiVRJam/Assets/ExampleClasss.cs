using UnityEngine;
using System.Collections;

public class ExampleClasss : MonoBehaviour {

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    private bool isMovingForward = true;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update()
    {
        Debug.Log(startTime);
    }


    void ForwardMovement()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

        if (gameObject.transform.position == endMarker.position)
        {
            isMovingForward = false;
        }

    }

    void BackwardMovement()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

        if (gameObject.transform.position == startMarker.position)
        {
            isMovingForward = false;
        }
    }



}
