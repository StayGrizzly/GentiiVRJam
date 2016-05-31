using UnityEngine;
using System.Collections;

public class Bibbit_Behaviour : MonoBehaviour {

    VRTK_InteractableObject m_InterObj;
    ParticleSystem m_Bibbits;
    GameObject m_GrabbingObject;
    bool m_IsParticleAwake = false;

	// Use this for initialization
	void Start ()
    {
        m_InterObj = gameObject.GetComponent<VRTK_InteractableObject>();
        if (m_InterObj !=  null)
        {
            Debug.Log("Script Located");
        }

        m_Bibbits = gameObject.transform.GetComponentInChildren<ParticleSystem>();
        if (m_Bibbits != null)
        {
            Debug.Log("Bibbits Located");
            m_Bibbits.Stop();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_InterObj.IsGrabbed() == true)
        {
            if (m_IsParticleAwake != true)
            {
                m_Bibbits.Play();
                m_IsParticleAwake = true;
                Debug.Log("Bibbit particle created");
                m_GrabbingObject = m_InterObj.GetGrabbingObject();
                if (m_GrabbingObject != null)
                {
                    Debug.Log("Grabbed Controller Located");
                }
            }

            else
            {
                m_GrabbingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(10, 200);
            }
        }

        else
        {
            m_Bibbits.Stop();
            m_IsParticleAwake = false;
            m_GrabbingObject = null;
        }
	}
}
