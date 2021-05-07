using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData _singleton;
    public GameObject _musicSlider;
    public GameObject _soundSlider;
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

        StartCoroutine(GetOptionsSliders());

    }

    IEnumerator GetOptionsSliders()
    {
        yield return new WaitForSeconds(1);
        _musicSlider.GetComponent<UpdateMusic>().Start();
        _soundSlider.GetComponent<UpdateSound>().Start();
    }
}
