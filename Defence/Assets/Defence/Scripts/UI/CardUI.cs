using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Camera _camerapos;
    bool _cardOn;

    public Image _image;
    public Text _name;
    public Text _text;
    public Sprite[] _sprite;

    public Image[] _buffimage;
    public Text[] _buffStack;
    public GameObject[] _modelImage;

    List<int> _skilllist;
    List<int> _skillStack;

    public int _buffMAX = 10;
    int count = 0;

    public GameObject _buffOpenUI;
    public GameObject _unitOpenUI;

    void Start()
    {
        _cardOn = false;
        _skilllist = new List<int>();
        _skillStack = new List<int>();
        _unitOpenUI.SetActive(false);
        _buffOpenUI.SetActive(false);
        for (int i=0; i<10;i++)
        {
            _skillStack.Add(1);
        }
    }


    void Update()
    {
        
    }
    public void Card()
    {
        if (_cardOn)
        {
            _unitOpenUI.SetActive(false);
            _buffOpenUI.SetActive(false);
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
        _image.enabled = false;
        _name.enabled = false;
        _text.enabled = false;
    }
    public void UnitCardSpwan()
    {
        unitoff();
        int rand = Random.Range(0, 3);
        switch (rand)
        {
            case 0:
                _name.text = "";
                _text.text = "아쳐\n\n소환 성공!!";
                break;
            case 1:
                _name.text = "";
                _text.text = "닌자\n\n소환 성공!!";
                break;
            case 2:
                _name.text = "";
                _text.text = "위자드\n\n소환 성공!!";
                break;
        }
        _text.enabled = true;
        _modelImage[rand].SetActive(true);
    }
    public void CardSpwan()
    {
        unitoff();
        int rand = Random.Range(0, 10);
        if(_skilllist.Contains(rand))//중복된 버프가 있다면?
        {
            if (_skillStack[rand] < _buffMAX)
            {
                //다이아차감
                _skillStack[rand]++;//3스택MAX
            }
            else//3스택이상이면
            {
                //다이아 돌려줌

            }
        }
        else//중복된 버프가 없으면?
        {
            _skilllist.Add(rand);//스킬리스트 추가
        }

        switch (rand)
        {
            case 0:
                _name.text = "PowerUp";
                _text.text = "모든 유닛 공격력 증가,공격속도 증가";
                break;
            case 1:
                _name.text = "DaggerPowerUp";
                _text.text = "닌자 공격력 증가";
                break;
            case 2:
                _name.text = "FlamePowerUp";
                _text.text = "위자드 공격력 증가";
                break;
            case 3:
                _name.text = "ArrowPowerUp";
                _text.text = "아처 공격력 증가";
                break;
            case 4:
                _name.text = "Flamedot";
                _text.text = "위자드 화염도트데미지추가";
                break;
            case 5:
                _name.text = "AddArrow";
                _text.text = "아처 추가공격증가";
                break;
            case 6:
                _name.text = "AddDagger";
                _text.text = "닌자 추가공격증가";
                break;
            case 7:
                _name.text = "CriticalArrow";
                _text.text = "아처 크리티컬확률 증가";
                break;
            case 8:
                _name.text = "CriticalDagger";
                _text.text = "닌자 크리티컬확률 증가";
                break;
            case 9:
                _name.text = "CriticalMagic";
                _text.text = "위자드 크리티컬확률 증가";
                break;
            case 10:
                _name.text = "ArrowPowerUp";
                _text.text = "아처 공격력 증가";
                break;
        }
        _image.sprite = _sprite[rand];
        buffinfo(rand);
        _image.enabled = true;
        _name.enabled = true;
        _text.enabled = true;
    }

    public void buffinfo(int num)
    {
        for(int i=0; i< _skilllist.Count; i++)
        {
            _buffimage[i].enabled = true;
            _buffimage[i].sprite = _sprite[_skilllist[i]];
            _buffStack[i].text = "x" + _skillStack[_skilllist[i]];
        }
    }

    public void UnitSpwan()
    {
        _buffOpenUI.SetActive(false);
        _unitOpenUI.SetActive(true);
        unitoff();
    }
    public void BuffSpwan()
    {
        _unitOpenUI.SetActive(false);
        _buffOpenUI.SetActive(true);
        unitoff();
    }
    public void unitoff()
    {
        for (int i = 0; i < _modelImage.Length; i++)
        {
            _modelImage[i].SetActive(false);
        }
        _image.enabled = false;
        _name.enabled = false;
        _text.enabled = false;
    }
}
