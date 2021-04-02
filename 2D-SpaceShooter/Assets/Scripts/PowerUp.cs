using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    [SerializeField] private int _powerupID;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * _speed * Time.deltaTime, Space.World);
        transform.Rotate(0, 0, 50 * Time.deltaTime); //rotates 50 degrees per second around z axis
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player player = collision.transform.GetComponent<Player>();
            if(player != null)
            {
                switch (_powerupID)
                {
                    case 0:
                        player.TripleShotActive();
                        break;
                    case 1:
                        player.SpeedBoostActive();
                        break;
                    case 2:
                        Debug.Log("Shields collected");
                        break;
                    default:
                        Debug.Log("Default case");
                        break;
                }
                Destroy(this.gameObject);
            }
        }
    }

}
