using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public List<SelectableCharacter> selectableChars = new List<SelectableCharacter>();

    private void Awake()
    {
        SelectableCharacter[] chars = FindObjectsOfType<SelectableCharacter>();
        for (int i = 0; i <= (chars.Length - 1); i++)
        {
            selectableChars.Add(chars[i]);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (SelectableCharacter soldier in selectableChars)
        {
            if(soldier.selectImage.enabled)
            {
                Debug.Log(soldier.transform.parent.gameObject.tag);
            }
        }
    }
}
