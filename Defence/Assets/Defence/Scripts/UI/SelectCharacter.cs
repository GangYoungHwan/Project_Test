using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacter : MonoBehaviour
{
    public List<SelectableCharacter> selectableChars = new List<SelectableCharacter>();
    int archer_cnt;
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
        if(SelectManager.Instance.selecting)
        {
            CheckSelected();
        }
    }
    void CheckSelected()
    {
        foreach (SelectableCharacter soldier in selectableChars)
        {
            if (soldier.selectImage.enabled)
            {
                if (soldier.transform.parent.gameObject.tag == "Archer")
                {
                    GameObject[] _find = GameObject.FindGameObjectsWithTag("Archer");
                    Debug.Log(_find.Length);
                }
                else if (soldier.transform.parent.gameObject.tag == "Wizard")
                {
                    GameObject[] _find = GameObject.FindGameObjectsWithTag("Wizard");
                    Debug.Log(_find.Length);
                }
                else if (soldier.transform.parent.gameObject.tag == "Ninja")
                {
                    GameObject[] _find = GameObject.FindGameObjectsWithTag("Ninja");
                    Debug.Log(_find.Length);
                }
            }
        }
    }
}
