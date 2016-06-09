using UnityEngine;
using System.Collections;

public class SoilEvent : MonoBehaviour {

    public GameObject m_VineWand;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Seed")
        {
            GameObject wand = (GameObject)Instantiate(m_VineWand, col.gameObject.transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
    }


}
