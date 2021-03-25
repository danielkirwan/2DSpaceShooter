using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Laser")
        {
            Debug.Log("Laser hit shredder");
            Destroy(other.gameObject);
        }
    }
}
