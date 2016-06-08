using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BibbitLine : MonoBehaviour {

    public GameObject m_Bibbit;
    GameObject m_Spawner;
    Queue<GameObject> m_SpawnedBibbits = new Queue<GameObject>();

	// Use this for initialization
	void Start ()
    {
        m_Spawner = transform.FindChild("Spawn").gameObject;
	}
	
	// Update is called once per frame
	void Update ()
    {
        /*if (m_SpawnedBibbits.Count < 5)
        {
            GameObject temp = (GameObject)Instantiate(m_Bibbit, m_Spawner.transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody>().AddForce(temp.transform.up * 1f);
            m_SpawnedBibbits.Enqueue(temp);
        }*/
	}
}
