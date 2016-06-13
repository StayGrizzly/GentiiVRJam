using UnityEngine;
using System.Collections;

public class TeleportToObject : MonoBehaviour {

    VRTK_SimplePointer m_Pointer;
    VRTK_ControllerEvents m_Controller;
    bool m_Teleported = false;
    GameObject m_CurrentTeleportPoint;
    GameObject m_PrevTeleportPoint;

    // Use this for initialization
    void Start ()
    {
        m_Pointer = gameObject.GetComponent<VRTK_SimplePointer>();
        m_Controller = gameObject.GetComponent<VRTK_ControllerEvents>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(m_Pointer.getHitObject() != null)
        {
            if(m_Pointer.getHitObject().tag == "Teleport Point")
            {
                if (m_Controller.gripPressed && m_Controller.grabPressed && m_Teleported == false)
                {
                    Debug.Log(m_Pointer.getHitObject().name);
                    if(m_CurrentTeleportPoint != null) { m_CurrentTeleportPoint.GetComponent<TeleporterBehaviour>().TurnOn(); }

                    m_Teleported = true;
                    Debug.Log(transform.parent.gameObject.name);
                    gameObject.transform.parent.position = new Vector3(m_Pointer.getHitObject().transform.position.x, gameObject.transform.parent.position.y, m_Pointer.getHitObject().transform.position.z);

                    m_CurrentTeleportPoint = m_Pointer.getHitObject();
                    m_CurrentTeleportPoint.GetComponent<TeleporterBehaviour>().TurnOff();

                    Debug.Log("TELEPORT!!!");
                }
            }

        }

        if(m_Controller.gripPressed != true && m_Controller.grabPressed != true && m_Teleported == true)
        {
            m_Teleported = false;
        }
	}
}
