using UnityEngine;
using System.Collections;

public class CleanableRubble : MonoBehaviour {


    public GameObject CleanedPile_pref;
    public GameObject CleaningParticles_pref;

    private GameObject RubblePile;
    private GameObject CurrentCleanedPile;
    private GameObject CurrentParticles;
    private bool isCleaned = false;

    // Use this for initialization
    void Start ()
    {
        RubblePile = gameObject.transform.GetChild((gameObject.transform.childCount)-1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bibbit" && isCleaned == false)
        {
            CurrentParticles = (GameObject)Instantiate(CleaningParticles_pref, RubblePile.transform.position, Quaternion.identity);
            CurrentCleanedPile = (GameObject)Instantiate(CleanedPile_pref, RubblePile.transform.position, Quaternion.identity);
            Destroy(RubblePile);
            isCleaned = true;
        }
    }
}
