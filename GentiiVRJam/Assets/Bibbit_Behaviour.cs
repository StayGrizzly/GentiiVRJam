using UnityEngine;
using System.Collections;

public class Bibbit_Behaviour : MonoBehaviour {

    VRTK_InteractableObject m_InterObj;
    GameObject m_GrabbingObject;
    bool m_IsRumbleDead = true;

    AudioSource m_AudioSource;
    public AudioClip m_IdleAudio;
    public AudioClip m_GrabbedAudio;
    bool m_IsStillGrabbed = true;
    bool m_IsStillIdle = false;

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
            SetNewAudio(m_IdleAudio, 1f, true);
            m_IsStillIdle = true;
        }
    }

	void Update ()
    {
        if (m_InterObj.IsGrabbed() == true)
        {
            UnfreezeBibbit();
            Debug.Log("Object Grabbed!");
            if (m_GrabbingObject == null)
            {
                m_GrabbingObject = m_InterObj.GetGrabbingObject();
                m_IsRumbleDead = false;
                m_IsStillIdle = false;
                m_IsStillGrabbed = false;
                Debug.Log("Grabbed Controller Located");
            }

            if (m_IsStillGrabbed != true)
            {
                SetNewAudio(m_GrabbedAudio, 1f, false);
                m_IsStillGrabbed = true;
            } 

            if (m_IsRumbleDead != true)
            {
                m_GrabbingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(50, 200);
                m_IsRumbleDead = true;
            }

        }

        if (m_InterObj.IsGrabbed() != true && m_IsStillIdle != true)
        {
            SetNewAudio(m_IdleAudio, 1f, true);
            m_IsStillIdle = true;
            m_IsStillGrabbed = false;
            m_GrabbingObject = null;
        }

      
	}

    private void SetNewAudio(AudioClip _newAudioClip, float _newVolume, bool _isLooping)
    {
        m_AudioSource.Stop();
        m_AudioSource.clip = _newAudioClip;
        m_AudioSource.volume = _newVolume;
        m_AudioSource.loop = _isLooping;
        m_AudioSource.Play();
    }

    public void FreezeBibbit()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void UnfreezeBibbit()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
