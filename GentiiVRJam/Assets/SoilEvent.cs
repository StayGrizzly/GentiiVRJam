using UnityEngine;
using System.Collections;

public class SoilEvent : MonoBehaviour {

    public GameObject m_VineWand;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Seed")
        {
            GameObject wand = (GameObject)Instantiate(m_VineWand, transform.position, Quaternion.identity);
            wand.transform.GetChild(0).GetComponent<Animation>().Play();
            Destroy(col.gameObject);
        }
    }


}
