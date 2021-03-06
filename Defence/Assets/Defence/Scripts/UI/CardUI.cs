using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public static CardUI instance;
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

    public int _buffAtt = 0;
    public int _buffAttSpeed = 1;
    public float _buffArcherAtt = 10;
    public float _buffNinjaAtt = 10;
    public float _buffWizardAtt = 20;

    //크리티컬 확률
    public int _buffArcherCritical = 0;
    public int _buffNinjaCritical = 0;
    public int _buffWizardCritical = 0;

    //크리티컬 데미지
    public float _buffArcherCriticalDmg = 0.0f;
    public float _buffNinjaCriticalDmg = 0.0f;
    public float _buffWizardCriticalDmg = 0.0f;

    //set
    public GameObject _setUI;
    bool _setUiOn = false;

    public GameObject _questUI;
    bool _questUiOn = false;
    void Start()
    {
        instance = this;
        _cardOn = false;
        _skilllist = new List<int>();
        _skillStack = new List<int>();
        _unitOpenUI.SetActive(false);
        _buffOpenUI.SetActive(false);
        _setUI.SetActive(false);
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
        SoundManager.Instance.PlaySFXSound("Menu",1);
        _questUI.SetActive(false);
        if (_cardOn)
        {
            this.gameObject.SetActive(false);
            unitoff();
            _unitOpenUI.SetActive(false);
            _buffOpenUI.SetActive(false);
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

        if (info.instance._gold >= 30)
        {
            unitoff();
            info.instance._gold -= 30;
            int rand = Random.Range(0, 3);
            switch (rand)
            {
                case 0:
                    _name.text = "";
                    _text.text = "아쳐\n\n소환 성공!!";
                    Quest.intance._archerSpwan++;
                    break;
                case 1:
                    _name.text = "";
                    _text.text = "닌자\n\n소환 성공!!";
                    Quest.intance._ninjaSpwan++;
                    break;
                case 2:
                    _name.text = "";
                    _text.text = "위자드\n\n소환 성공!!";
                    Quest.intance._wizardSpwan++;
                    break;
            }
            _text.enabled = true;
            _modelImage[rand].SetActive(true);
            GameObject.Find("GameManager").GetComponent<Spwan>().UnitSpwan(rand);
        }
        else
        {
            Debug.Log("골드가 부족합니다");
        }
    }
    public void CardSpwan()
    {
        if (info.instance._dia >= 1)
        {
            info.instance._dia -= 1;
            unitoff();
            int rand = Random.Range(0, 10);
            if (_skilllist.Contains(rand))//중복된 버프가 있다면?
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
                    _buffAtt += 10;
                    if (_buffAttSpeed < 3)
                    {
                        _name.text = "PowerUp";
                        _text.text = "모든 유닛 공격력 증가,공격속도 증가";
                        _buffAttSpeed++;
                    }
                    else
                    {
                        _name.text = "PowerUp";
                        _text.text = "모든 유닛 공격력 증가,공격속도 MAX";
                    }
                    break;
                case 1:
                    _name.text = "DaggerPowerUp";
                    _text.text = "닌자 공격력 증가";
                    _buffNinjaAtt += 10;
                    break;
                case 2:
                    _name.text = "FlamePowerUp";
                    _text.text = "위자드 공격력 증가";
                    _buffWizardAtt += 15;
                    break;
                case 3:
                    _name.text = "ArrowPowerUp";
                    _text.text = "아처 공격력 증가";
                    _buffArcherAtt += 10;
                    break;
                case 4:
                    _name.text = "Flamedot";
                    _text.text = "위자드 크리티컬데미지 증가";
                    _buffWizardCriticalDmg += 0.3f;
                    break;
                case 5:
                    _name.text = "AddArrow";
                    _text.text = "아처 크리티컬데미지 증가";
                    _buffArcherCriticalDmg += 0.3f;
                    break;
                case 6:
                    _name.text = "DarkNess";
                    _text.text = "닌자 크리티컬데미지 증가";
                    _buffNinjaCriticalDmg += 0.3f;
                    break;
                case 7:
                    _name.text = "CriticalArrow";
                    _text.text = "아처 크리티컬확률 증가";
                    _buffArcherCritical += 10;
                    break;
                case 8:
                    _name.text = "CriticalDagger";
                    _text.text = "닌자 크리티컬확률 증가";
                    _buffNinjaCritical += 10;
                    break;
                case 9:
                    _name.text = "CriticalMagic";
                    _text.text = "위자드 크리티컬확률 증가";
                    _buffWizardCritical += 10;
                    break;
                case 10:
                    _name.text = "미정";
                    _text.text = "미정";
                    break;
            }
            _image.sprite = _sprite[rand];
            buffinfo(rand);
            _image.enabled = true;
            _name.enabled = true;
            _text.enabled = true;
        }
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

    public void SetOnOff()
    {
        SoundManager.Instance.PlaySFXSound("Menu", 1);
        if (_setUiOn)
        {
            _setUI.SetActive(true);
            _setUiOn = false;
        }
        else
        {
            _setUI.SetActive(false);
            _setUiOn = true;
        }
    }

    public void close()
    {
        SoundManager.Instance.PlaySFXSound("Menu", 1);
        _setUI.SetActive(false);
    }

    public void QuestUI()
    {
        SoundManager.Instance.PlaySFXSound("Menu", 1);
        this.gameObject.SetActive(false);
        if (_questUiOn)
        {
            _questUI.SetActive(true);
            _camerapos.transform.position = new Vector3(44, 35, 12);
            _questUiOn = false;
        }
        else
        {
            _questUI.SetActive(false);
            
            _camerapos.transform.position = new Vector3(36, 35, 4);
            _questUiOn = true;
        }
    }
}
