using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRot : MonoBehaviour
{
    float rotSpeed = 15.0f;

    void Update()
    {
        transform.Rotate(new Vector3(0,0,Time.deltaTime*rotSpeed));
    }
}
