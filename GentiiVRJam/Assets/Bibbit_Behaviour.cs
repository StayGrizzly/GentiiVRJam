using UnityEngine;
using System.Collections;

public class Bibbit_Behaviour : MonoBehaviour {

    VRTK_InteractableObject m_InterObj;
    //ParticleSystem m_Bibbits;
    GameObject m_GrabbingObject;
    //bool m_IsParticleAwake = false;
    bool m_IsRumbleDead = true;

	void Start ()
    {
        m_InterObj = gameObject.GetComponent<VRTK_InteractableObject>();
        if (m_InterObj !=  null)
        {
            Debug.Log("Script Located");
        }
        /*
        m_Bibbits = gameObject.transform.GetComponentInChildren<ParticleSystem>();
        if (m_Bibbits != null)
        {
            Debug.Log("Bibbits Located");
            m_Bibbits.Stop();
        }
        */
	}

	void Update ()
    {
        if (m_InterObj.IsGrabbed() == true)
        {
            if (m_GrabbingObject == null)
            {
                m_GrabbingObject = m_InterObj.GetGrabbingObject();
                m_IsRumbleDead = false;
                Debug.Log("Grabbed Controller Located");
            }

            if (m_IsRumbleDead != true)
            {
                m_GrabbingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(50, 200);
                m_IsRumbleDead = true;
            }

        }

        else
        {
            m_IsRumbleDead = false;
            /*
            m_Bibbits.Stop();
            m_IsParticleAwake = false;
            m_GrabbingObject = null;
            */
        }
	}
}
