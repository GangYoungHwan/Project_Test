using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Camera _camerapos;
    bool _cardOn;
    void Start()
    {
        _cardOn = false;
    }


    void Update()
    {
        
    }
    public void Card()
    {
        if (_cardOn)
        {
            this.gameObject.SetActive(false);
            _camerapos.transform.position = new Vector3(36, 35, 4);
            _cardOn = false;
        }
        else
        {
            this.gameObject.SetActive(true);
            _camerapos.transform.position = new Vector3(44, 35, 12);
            _cardOn = true;
        }
    }

    public void CardSpwan()
    {

    }
}
