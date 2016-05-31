using UnityEngine;
using System.Collections;

public class Bibbit_Behaviour : MonoBehaviour {

    VRTK_InteractableObject m_InterObj;
    GameObject m_GrabbingObject;
    bool m_IsRumbleDead = true;

    AudioSource m_AudioSource;
    public AudioClip m_IdleAudio;
    public AudioClip m_GrabbedAudio;

	void Start ()
    {
        m_InterObj = gameObject.GetComponent<VRTK_InteractableObject>();
        if (m_InterObj !=  null)
        {
            Debug.Log("Script Located");
        }

        m_AudioSource = gameObject.GetComponent<AudioSource>();
        if (m_InterObj != null)
        {
            Debug.Log("Audio Source Located");
            m_AudioSource.clip = m_IdleAudio;
        }
    }

	void Update ()
    {
        if (m_InterObj.IsGrabbed() == true)
        {
            if (m_GrabbingObject == null)
            {
                m_GrabbingObject = m_InterObj.GetGrabbingObject();
                m_IsRumbleDead = false;
                m_AudioSource.clip = m_GrabbedAudio;
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
            m_AudioSource.clip = m_IdleAudio;
        }
	}
}
