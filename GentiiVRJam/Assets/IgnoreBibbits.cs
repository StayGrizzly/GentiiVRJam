using UnityEngine;
using System.Collections;

public class IgnoreBibbits : MonoBehaviour {
    
    void OnCollisionEnter(Collision col)
    {
        if (gameObject.name != "SPAWN")
            if (col.gameObject.tag == "Bibbit")
                Debug.Log("Bibbit hit Flag");
    }
    
}
