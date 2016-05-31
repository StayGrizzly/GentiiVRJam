using UnityEngine;
using System.Collections;

public class Bibbit_Behaviour : MonoBehaviour {

    VRTK_InteractableObject m_InterObj;
    GameObject m_GrabbingObject;
    bool m_IsRumbleDead = true;
    bool m_IsNewAudioRunning = true;

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

        m_AudioSource = gameObject.AddComponent<AudioSource>();
        if (m_InterObj != null)
        {
            Debug.Log("Audio Source Located");
            SetNewAudio(m_IdleAudio, 1f, true);
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
                m_IsNewAudioRunning = false;
                Debug.Log("Grabbed Controller Located");
            }

            if (m_IsNewAudioRunning != true)
            {
                SetNewAudio(m_GrabbedAudio, 1f, true);
                m_IsNewAudioRunning = true;
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
            m_IsNewAudioRunning = false;
            SetNewAudio(m_IdleAudio, 1f, true);
        }
	}

    private void SetNewAudio(AudioClip _newAudioClip, float _newVolume, bool _isLooping)
    {
        m_AudioSource.Stop();
        m_AudioSource.clip = _newAudioClip;
        //m_AudioSource.volume = _newVolume;
        //m_AudioSource.loop = _isLooping;
        m_AudioSource.Play();
    }
}
