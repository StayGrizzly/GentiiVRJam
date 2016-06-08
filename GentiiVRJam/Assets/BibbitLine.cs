using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BibbitLine : MonoBehaviour {

    // CUSTOMIZABLE VARIABLES
    public List<GameObject> m_LinePoints;
    public GameObject m_Bibbit;
    public int m_MaxBibbits;
    public float m_BibbitSpeed = 1.0F;
    public float m_BibbitSpawnRate;

    // BIBBIT VARIABLES
    private GameObject m_Spawn;
    private List<GameObject> m_SpawnedBibbits = new List<GameObject>();

    // BIBBIT TIMER
    private float m_StartTime;
    private float m_ElapsedTime;

    // THE BEEF
    void Start ()
    {
        m_Spawn = transform.FindChild("Spawn").gameObject;
        m_StartTime = Time.time;
	}
	
    // MORE BEEF
	void Update ()
    {
        m_ElapsedTime = Time.time - m_StartTime;
        if (m_SpawnedBibbits.Count < m_MaxBibbits)
        {
            if (m_ElapsedTime >= m_BibbitSpawnRate || m_SpawnedBibbits.Count == 0)
            {
                SpawnNewBibbit();
                m_StartTime = Time.time;
            }
        }

        CheckIfBibbitsDone();

	}

    void SpawnNewBibbit()
    {
        GameObject temp = (GameObject)Instantiate(m_Bibbit, m_Spawn.transform.position, Quaternion.identity);
        m_SpawnedBibbits.Add(temp);
        temp.AddComponent<Cleaning_Bibbit>();
        temp.GetComponent<Cleaning_Bibbit>().SetSpeed(m_BibbitSpeed);
        temp.GetComponent<Cleaning_Bibbit>().AddToTravelFlags(m_Spawn.transform);
        SetToPath(temp);
    }

    void CheckIfBibbitsDone()
    {
        for (int i = 0; i < m_SpawnedBibbits.Count; ++i)
        {
            if (m_SpawnedBibbits[i].GetComponent<Cleaning_Bibbit>().GetIfCompletedRoute() == true)
            {
                GameObject temp = m_SpawnedBibbits[i];
                m_SpawnedBibbits.RemoveAt(i);
                Destroy(temp);
            }
        }
    }

    // ADDS FLAGS TO INDIVIDUAL SPAWNED BIBBITS
    void SetToPath(GameObject _bibbit)
    {
        for (int i = 0; i < m_LinePoints.Count; ++i)
        {
            _bibbit.GetComponent<Cleaning_Bibbit>().AddToTravelFlags(m_LinePoints[i].transform);
        }
    }
}
