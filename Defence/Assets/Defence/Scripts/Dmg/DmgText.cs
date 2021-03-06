using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DmgText : MonoBehaviour
{
    private float _moveSpeed;
    private float _alphaSpeed;
    private float _destroyTime;
    TextMeshPro text;
    //Text text;
    Color _alpha;
    public float damage;
    
    void Start()
    {
        _moveSpeed = 0.1f;
        _alphaSpeed = 0.03f;
        _destroyTime = 0.5f;
        text = GetComponent<TextMeshPro>();
        _alpha = text.color;
        text.text = damage.ToString();
        Invoke("DestroyObject", _destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, _moveSpeed, 0));
        _alpha.a = Mathf.Lerp(_alpha.a, 0, _alphaSpeed);
        text.color = _alpha;
    }

    private void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
