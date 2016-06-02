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

    GameObject m_TouchingObject;

    /* FOR CHANGING BIBBIT MATERIAL
    GameObject m_BibbitMesh;
    GameObject m_Particles;
    GameObject m_Trails;
    GameObject m_EyeLid;
    */

    void Start ()
    {
        m_InterObj = gameObject.GetComponent<VRTK_InteractableObject>();
        if (m_InterObj !=  null)
        {
            //Debug.Log("Script Located");
        }

        m_AudioSource = gameObject.GetComponent<AudioSource>();
        if (m_InterObj != null)
        {
            //Debug.Log("Audio Source Located");
            SetNewAudio(m_IdleAudio, .5f, true);
            m_IsStillIdle = true;
        }

        /*
        m_BibbitMesh = gameObject.transform.FindChild("bibbit_mesh").gameObject;
        Debug.Log(m_BibbitMesh.transform.childCount);

        m_Particles = m_BibbitMesh.transform.FindChild("bibbit_mesh_particle").gameObject;
        m_Trails = m_BibbitMesh.transform.FindChild("bibbit_mesh_particle").gameObject;
        m_EyeLid = m_BibbitMesh.transform.FindChild("eyes_pivot").gameObject.transform.FindChild("eyeball_look").gameObject.transform.FindChild("eye_animation").gameObject.transform.FindChild("eye_lid").gameObject;
        */
    }

	void Update ()
    {

        if (m_InterObj.IsTouched() == true && m_InterObj.IsGrabbed() != true)
        {
            m_TouchingObject = m_InterObj.GetTouchingObject();
            m_TouchingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(1, 500);
        }

        if (m_InterObj.IsGrabbed() == true)
        {
            UnfreezeBibbit();
            //Debug.Log("Object Grabbed!");
            if (m_GrabbingObject == null)
            {
                m_GrabbingObject = m_InterObj.GetGrabbingObject();
                m_IsRumbleDead = false;
                m_IsStillIdle = false;
                m_IsStillGrabbed = false;
                //Debug.Log("Grabbed Controller Located");
            }



            if (m_IsStillGrabbed != true)
            {
                SetNewAudio(m_GrabbedAudio, 1f, false);
                m_IsStillGrabbed = true;
            }

            if (m_IsRumbleDead != true)
            {

                m_GrabbingObject.GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(50, 3000);
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


    /* CHANGING BIBBIT COLORS

    public void SetMaterial(Material _material)
    {
        m_Particles.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = _material;
        m_Trails.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = _material;
        m_EyeLid.GetComponent<Renderer>().material = _material;
    }

    */

    public void FreezeBibbit()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void UnfreezeBibbit()
    {
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
}
