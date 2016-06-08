using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BibbitLine : MonoBehaviour {


    // BIBBIT VARIABLES
    public GameObject m_Bibbit;
    List<GameObject> m_SpawnedBibbits = new List<GameObject>();

    // LERP VARIABLES
    public float m_BibbitSpeed = 1.0F;
    private bool isMovingForward = true;


    // MOVEMENT POINTS
    GameObject m_Spawn;
    public List<GameObject> m_LinePoints;



    // Use this for initialization
    void Start ()
    {
        m_Spawn = transform.FindChild("Spawn").gameObject;
        
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if (m_SpawnedBibbits.Count < 1)
        {
            GameObject temp = (GameObject)Instantiate(m_Bibbit, m_Spawn.transform.position, Quaternion.identity);
            m_SpawnedBibbits.Add(temp);
            temp.AddComponent<Cleaning_Bibbit>();
            temp.GetComponent<Cleaning_Bibbit>().SetSpeed(m_BibbitSpeed);
            temp.GetComponent<Cleaning_Bibbit>().AddToTravelFlags(m_Spawn.transform);
            SetToPath(temp);
        }
	}

    void SetToPath(GameObject _bibbit)
    {
        for (int i = 0; i < m_LinePoints.Count; ++i)
        {
            _bibbit.GetComponent<Cleaning_Bibbit>().AddToTravelFlags(m_LinePoints[i].transform);
        }
    }
}
