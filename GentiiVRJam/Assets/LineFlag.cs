using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LineFlag : MonoBehaviour {

    List<Transform> m_FlagOptions = new List<Transform>();
    bool m_IsGrounded = false;

    public bool GetIfObjGrabbed()
    {
        return transform.FindChild("Sign").GetComponent<VRTK_InteractableObject>().IsGrabbed();
    }

    public bool GetIfGrounded()
    {
        return transform.FindChild("Sign").gameObject.transform.FindChild("Ground Collider").GetComponent<GroundCollider>().GetIsGrounded();
    }

    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            if(transform.GetChild(i).name != "Sign")
            {
                Debug.Log(transform.name + "'s " + transform.GetChild(i).name);
                m_FlagOptions.Add(transform.GetChild(i));
            }
            // Debug.Log(m_FlagOptions[i].gameObject.name);
        }
    }


    public Transform GetRandomFlagTransform()
    {
        return m_FlagOptions[(int)Random.Range(0, m_FlagOptions.Count)];
    }
}
