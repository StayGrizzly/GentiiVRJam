using UnityEngine;
using System.Collections;

public class BibbitKiller : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bibbit")
        {
            Destroy(other.gameObject);
        }
    }
}
