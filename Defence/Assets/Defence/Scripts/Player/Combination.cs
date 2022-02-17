using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combination : MonoBehaviour
{
    public GameObject _button;
    public List<SelectableCharacter> selectableChars = new List<SelectableCharacter>();

    public GameObject Archer;
    public GameObject Ninja;
    public GameObject Wizard;
    public ParticleSystem _spwanEffect;
    public Transform _spwanPoint;
    void Start()
    {
        _spwanEffect.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //OnClickCombination();
    }

    /*
    public void OnClickCombination()//수정
    {
        //selectableChars = SelectManager.Instance.selectedArmy;
        foreach (SelectableCharacter soldier in SelectManager.Instance.selectedArmy)
        {
            if (soldier.selectImage.enabled)
            {
                if (soldier.transform.parent.gameObject.tag == "Archer")
                {
                    //GameObject[] _find = GameObject.FindGameObjectsWithTag("Archer");
                    ////Debug.Log("a"+(_find.Length-1));
                    //for(int i= 0; i<_find.Length-1; i++)
                    //{
                    //    //Destroy(_find[i]);
                    //    Debug.Log(_find[i].name+"아처"+i);
                    //}
                    Debug.Log(soldier.tag);
                    Destroy(soldier.transform.parent.gameObject);
                }
                else if (soldier.transform.parent.gameObject.tag == "Wizard")
                {
                    GameObject[] _find = GameObject.FindGameObjectsWithTag("Wizard");
                    //Debug.Log("b" + (_find.Length-1));
                }
                else if (soldier.transform.parent.gameObject.tag == "Ninja")
                {
                    GameObject[] _find = GameObject.FindGameObjectsWithTag("Ninja");
                    //Debug.Log("c" + (_find.Length-1));
                }
            }
        }
    }
    */
    public void OnClickCombination()//수정
    {
        SoundManager.Instance.PlaySFXSound("Menu", 1);
        GameObject[] _archer = GameObject.FindGameObjectsWithTag("Archer");
        GameObject[] _ninja = GameObject.FindGameObjectsWithTag("Ninja");
        GameObject[] _wizard = GameObject.FindGameObjectsWithTag("Wizard");
        bool _archerSpwan = false;
        bool _ninjaSpwan = false;
        bool _wizardSpwan = false;
        int lv = 0;
        for (int i = 0; i < 5; i++)
        {
            if (LevelChecking(_archer, i))//아처
            {
                PlayerDestory(_archer, i);
                _archerSpwan = true;
                lv = i+1;
            }
            else if (LevelChecking(_ninja, i))//아처
            {
                PlayerDestory(_ninja, i);
                _ninjaSpwan = true;
                lv = i + 1;
            }
            else if (LevelChecking(_wizard, i))//아처
            {
                PlayerDestory(_wizard, i);
                _wizardSpwan = true;
                lv = i + 1;
            }
        }
        if(_archerSpwan)//합성에 성공했을때
        {
            _spwanEffect.Play();
            GameObject obj = Instantiate(Archer, _spwanPoint.position, _spwanPoint.rotation) as GameObject;
            obj.GetComponent<Player>()._playerLevel = lv;
        }
        else if (_ninjaSpwan)//합성에 성공했을때
        {
            _spwanEffect.Play();
            GameObject obj = Instantiate(Ninja, _spwanPoint.position, _spwanPoint.rotation) as GameObject;
            obj.GetComponent<Player>()._playerLevel = lv;
        }
        else if (_wizardSpwan)//합성에 성공했을때
        {
            _spwanEffect.Play();
            GameObject obj = Instantiate(Wizard, _spwanPoint.position, _spwanPoint.rotation) as GameObject;
            obj.GetComponent<Player>()._playerLevel = lv;
        }
    }

    private bool LevelChecking(GameObject[] player,int level)
    {
        int Lv0 = 0;
        int Lv1 = 0;
        int Lv2 = 0;
        int Lv3 = 0;
        int Lv4 = 0;
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].GetComponent<SelectableCharacter>().selectImage.enabled)
            {
                if (player[i].GetComponentInParent<Player>()._playerLevel == 0)
                {
                    Lv0++;
                }
                else if (player[i].GetComponentInParent<Player>()._playerLevel == 1)
                {
                    Lv1++;
                }
                else if (player[i].GetComponentInParent<Player>()._playerLevel == 2)
                {
                    Lv2++;
                }
                else if (player[i].GetComponentInParent<Player>()._playerLevel == 3)
                {
                    Lv3++;
                }
                else if (player[i].GetComponentInParent<Player>()._playerLevel == 4)
                {
                    Lv4++;
                }
            }
        }
        if (level == 0 && Lv0 >= 3) return true;
        else if (level == 1 && Lv1 >= 3) return true;
        else if (level == 2 && Lv2 >= 3) return true;
        else if (level == 3 && Lv3 >= 3) return true;
        else if (level == 4 && Lv4 >= 3) return true;
        return false;
    }

    private void PlayerDestory(GameObject[] player, int level)
    {
        int count = 0;
        for (int i = 0; i < player.Length; i++)
        {
            if (player[i].GetComponent<SelectableCharacter>().selectImage.enabled)
            {
                if (player[i].GetComponentInParent<Player>()._playerLevel == level)
                {
                    if(count <3) Destroy(player[i].transform.parent.gameObject);
                    count++;
                }
            }
        }
    }
}
