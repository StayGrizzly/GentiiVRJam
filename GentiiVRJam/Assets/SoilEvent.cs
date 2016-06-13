using UnityEngine;
using System.Collections;

public class SoilEvent : MonoBehaviour {

    public GameObject m_VineWand;
    public GameObject m_ParticleFX;
    GameObject wand;
    private bool m_HasAnimPlayed = false;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Seed")
        {
            Destroy(col.gameObject);
            wand = (GameObject)Instantiate(m_VineWand, new Vector3(transform.position.x, transform.position.y+.25f, transform.position.z), Quaternion.identity);
            GameObject particle = (GameObject)Instantiate(m_ParticleFX, new Vector3(transform.position.x, transform.position.y + .5f, transform.position.z), Quaternion.Euler(-90, 0, 0));
        }
    }
    /*
    void Update()
    {
        if (wand.GetComponent<Animation>().isPlaying == false && m_HasAnimPlayed == true)
        {
            GameObject finalwand = (GameObject)Instantiate(m_VineWand, wand.transform.position, Quaternion.identity);
            Destroy(wand);
            Destroy(gameObject);
        }
    }
    */

}
