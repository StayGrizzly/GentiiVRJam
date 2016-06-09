using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class LineFlag : MonoBehaviour {

    List<Transform> m_FlagOptions = new List<Transform>();
    
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            m_FlagOptions.Add(transform.GetChild(i));
            //Debug.Log(m_FlagOptions[i].gameObject.name);
        }
    }


    public Transform GetRandomFlagTransform()
    {
        return m_FlagOptions[(int)Random.Range(0, m_FlagOptions.Count)];
    }


}
