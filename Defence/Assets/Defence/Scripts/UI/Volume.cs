using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider _volume;
    Text _volumeText;
    void Start()
    {
        _volumeText = GetComponent<Text>();
        _volume.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        int Vol = (int)_volume.value;
        _volumeText.text = Vol.ToString()+"%";
    }
}
