using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CleanableRubble : MonoBehaviour
{
    private GameObject m_CurrentRubble;
    public GameObject[] m_RubblePrefabs;

    private GameObject m_CurrentParticle;
    public GameObject m_ParticlePrefab;

    public Vector3 m_RubblePoint;

    int BibbitCount = 0;
    
    void Start()
    {
        m_CurrentRubble = (GameObject)Instantiate(m_RubblePrefabs[BibbitCount], m_RubblePoint, Quaternion.identity);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bibbit" && BibbitCount < 3)
        {
            BibbitCount++;
            Destroy(other.gameObject);
            Debug.Log("Bibbit Killed");
            //Debug.Log(BibbitCount);

            CleanRubble();

        }
    }

    void CleanRubble()
    {
        Destroy(m_CurrentRubble);
        Destroy(m_CurrentParticle);
        m_CurrentRubble = (GameObject)Instantiate(m_RubblePrefabs[BibbitCount], m_RubblePoint, Quaternion.identity);
        m_CurrentParticle = (GameObject)Instantiate(m_ParticlePrefab, m_RubblePoint, Quaternion.identity);
    }
}
