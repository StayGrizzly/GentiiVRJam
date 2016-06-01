using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BibbitsMananger : MonoBehaviour {

    public GameObject[] m_BibbitHoles;
    public GameObject[] m_BibbitPrefabs;

    int BibbitHole;
    int BibbitType;

    bool isBibbitPlaced;

    // Use this for initialization
    void Start ()
    {
        PlaceNewBibbit();
    }
	
	// Update is called once per frame
	void Update ()
    {
        // test = Random.Range(0, m_BibbitPrefabs.Length);
        // Debug.Log(test);


        // Place Bibbit (only if it's not there)
        // Check if bibbit is still there
        // if bibbit is gone then confirm buffer


	}

    private void PlaceNewBibbit()
    {

    }



}
