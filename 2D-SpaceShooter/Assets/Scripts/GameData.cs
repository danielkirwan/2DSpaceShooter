using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData _singleton;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] gd = GameObject.FindGameObjectsWithTag("GameData");
        if(gd.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        _singleton = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
