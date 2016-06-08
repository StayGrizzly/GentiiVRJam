using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cleaning_Bibbit : MonoBehaviour {


    // LERPING FLAGS
    public List<Transform> m_TravelFlags = new List<Transform>();
    public List<Transform> m_BackFlags = new List<Transform>();

    // LERPING VARIABLES
    public float m_MovementSpeed;
    private float m_StartTime;
    private float m_JourneyLength;
    private bool m_IsMovingForward = true;


    public Transform DEBUG_TEST_LOC_S;
    public Transform DEBUG_TEST_LOC_M;
    public Transform DEBUG_TEST_LOC_E;
    bool DEBUG_DONE_MOVING = false;
    int DEBUG_FORWARD_REPS = 0;
    int DEBUG_BACKWARD_REPS = 0;

    public void SetSpeed(float _speed)
    {
        m_MovementSpeed = _speed;
    }


    public void AddToTravelFlags(Transform _transform)
    {
        m_TravelFlags.Add(_transform);
    }

	// Use this for initialization
	void Start ()
    {
        m_StartTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_TravelFlags.Count > 0 || m_BackFlags.Count > 0)
        {
            Debug.Log("There are flags!");
            if (m_IsMovingForward)
            {

                MoveForward();
            }

            else
            {
                MoveBackward();
            }
        }
    }


    void MoveForward()
    {
        Debug.Log("Moving Forward!");

        Lerp(m_TravelFlags[0], m_TravelFlags[1]);

        if (DEBUG_DONE_MOVING)
        {
            m_BackFlags.Add(m_TravelFlags[0]);
            m_TravelFlags.RemoveAt(0);
            DEBUG_DONE_MOVING = false;
        }

        Debug.Log("Travel Flag Count: " + m_TravelFlags.Count);
        if (m_TravelFlags.Count == 1)
            {
                Debug.Log("Done Moving Forward!");
                m_BackFlags.Add(m_TravelFlags[0]);
                m_TravelFlags.RemoveAt(0);

                m_IsMovingForward = false;
                DEBUG_DONE_MOVING = false;
                ++DEBUG_FORWARD_REPS;
                Debug.Log("FORWARD REPS: " + DEBUG_FORWARD_REPS);
                m_BackFlags.Reverse();
            }
    }

    void MoveBackward()
    {
        Debug.Log("Moving Backward!");

        Lerp(m_BackFlags[0], m_BackFlags[1]);

        if (DEBUG_DONE_MOVING)
        {
            m_TravelFlags.Add(m_BackFlags[0]);
            m_BackFlags.RemoveAt(0);
            DEBUG_DONE_MOVING = false;
        }

        if (m_BackFlags.Count == 1)
        {
            Debug.Log("Done Moving Backward!");
            m_TravelFlags.Add(m_BackFlags[0]);
            m_BackFlags.RemoveAt(0);

            m_IsMovingForward = true;
            DEBUG_DONE_MOVING = false;
            ++DEBUG_BACKWARD_REPS;
            Debug.Log("BACKWARD REPS: " + DEBUG_BACKWARD_REPS);
            m_TravelFlags.Reverse();
        }
    }



    void Lerp(Transform _start, Transform _end)
    {
        gameObject.transform.position = _start.position;

        if (gameObject.transform.position == _start.position)
        {
            m_JourneyLength = Vector3.Distance(_start.position, _end.position);
        }


        float distCovered = (Time.time - m_StartTime) * m_MovementSpeed;
        float fracJourney = distCovered / m_JourneyLength;
        transform.position = Vector3.Lerp(_start.position, _end.position, fracJourney);

        if (gameObject.transform.position == _end.position)
        {
            // isDoneWithMove = true;
            m_StartTime = Time.time;
            DEBUG_DONE_MOVING = true;
        }
    }

}
