using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Laser")
        {
            if (other.transform.parent != null)
            {
                Destroy(other.transform.parent.gameObject);
            }
            Destroy(other.gameObject);
        }

        if(other.gameObject.tag == "Tshot")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Sboost")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Shield")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "EnemyLaser")
        {
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Ammo")
        {
            Destroy(other.gameObject);
        }
    }
}
