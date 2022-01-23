using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUI : MonoBehaviour
{
    float _speed = 3.0f;
    Vector3 _target;
    CanvasGroup _renderer;
    public Text _text;
    void Start()
    {
        _target = this.transform.position + new Vector3(0, 20, 0);
        _renderer = this.GetComponent<CanvasGroup>();
        StartCoroutine("FadeIn");
        if(this.tag == "Dia") _text.text = "" + info.instance._getDia;
        else if (this.tag == "Gold") _text.text = ""+info.instance._getGold;
        else if (this.tag == "Exp") _text.text = "" + info.instance._getExp;
        else _text.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, _target, _speed);
    }

    IEnumerator FadeIn()
    {
        Debug.Log("실행중");
        float f = 1;
        while(f>0)
        {
            f -= 0.05f;
            _renderer.alpha = f;
            yield return new WaitForSeconds(0.1f);
        }
        Destroy(this.gameObject);
    }
}
