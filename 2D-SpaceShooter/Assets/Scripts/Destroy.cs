using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Laser")
        {
            Debug.Log("Laser hit shredder");
            Destroy(other.gameObject);
        }else if(other.gameObject.tag == "Tshot")
        {
            Debug.Log("Tshot hit wall");
            Destroy(other.gameObject);
        }
    }
}
