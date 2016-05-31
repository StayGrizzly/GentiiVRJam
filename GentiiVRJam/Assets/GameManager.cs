using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    VRTK_ControllerEvents m_LeftController;
    VRTK_ControllerEvents m_RightController;

    // Use this for initialization
    void Start ()
    {
        m_LeftController = transform.FindChild("Controller (left)").GetComponent<VRTK_ControllerEvents>();
        m_RightController = transform.FindChild("Controller (right)").GetComponent<VRTK_ControllerEvents>();

        if (m_LeftController != null)
        {
            Debug.Log("Left is Loaded");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(m_LeftController.touchpadPressed == true || m_RightController.touchpadPressed == true)
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
