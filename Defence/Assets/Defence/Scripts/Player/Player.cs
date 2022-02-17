using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Player : MonoBehaviour
{
    public static Player instance;
    Animator _animator;
    NavMeshAgent _agent;
    public float _Distance = 15.0f;

    List<GameObject> FoundObjects;
    public GameObject _target;
    float shortDis;

    float _attackDelay = 1.0f;
    float _lastAttack = 0.0f;
    float _attackSpeed = 1.0f;

    public GameObject _waepon;
    public GameObject _waepon2;
    public Transform _firePosition;
    List<GameObject> _arr;
    bool moving;
    bool Attacking;


    public int AttackSpeed = 1;
    public float ArcherDamage = 10;
    public float NinjaDamage = 10;
    public float WizardDamage = 20;

    public int _playerLevel;
    //크리티컬 확률
    public int ArcherCritical = 0;
    public int NinjaCritical = 0;
    public int WizardCritical = 0;

    public bool ArcherCriticalOn = false;
    public bool NinjaCriticalOn = false;
    public bool WizardCriticalOn = false;

    //크리티컬 데미지
    public float ArcherCriticalDmg = 35;
    public float NinjaCriticalDmg = 35;
    public float WizardCriticalDmg = 45;

    public int ArcherRand = 0;
    public int NinjaRand = 0;
    public int WizardRand = 0;
    void Start()
    {
        instance = this;
        moving = false;
        _animator = this.GetComponent<Animator>();
        _agent = this.GetComponent<NavMeshAgent>();
        _arr = new List<GameObject>();
    }

    void Update()
    {
        MovingCheck();
        PlayerBuff();
        PlayerLevel();
        if (moving)//이동할때
        {
            UpdateAnimator();
        }
        else//이동을 멈출때
        {
            Targeting();//타겟팅 찾기
            if (_target != null)//이동을 멈추고 타겟팅이 있다면?
            {
                if (IsinRange() == true)//타겟팅이 사거리안에 있다면?
                {
                    AttackSpeeding(AttackSpeed);//공격속도조절
                    _lastAttack += Time.deltaTime;
                    if (_lastAttack < _attackDelay) UpdateAnimator();//공격딜레이
                    else AttackTrigger();//공격딜레이가 끝났다면 공격
                }
                else UpdateAnimator();//타겟팅이 사거리 없다면?
            }
            else UpdateAnimator();// 이동을 멈추고 타겟팅이 없다면?
        }
    }
    private void UpdateAnimator()
    {
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        _animator.SetFloat("MoveSpeed", local.z);
    }

    void StopAttack(float delay)
    {
        _agent.isStopped = false;
        _animator.ResetTrigger("Attack");
        _animator.SetTrigger("StopAttack");
        _lastAttack = delay;
    }

    void ArrowAttack()
    {
        _animator.SetFloat("MoveSpeed", 0);
        int ArrowDamage = Random.Range((int)ArcherDamage / 2, (int)ArcherDamage);
        GameObject arrow = Instantiate(_waepon);
        arrow.transform.position = _firePosition.position;
        if (_target != null) arrow.GetComponent<Arrow>().TargetFind(_target.transform);
        ArcherRand = Random.Range(0, 100);
        if (ArcherRand < ArcherCritical)//크리티컬
        {
            arrow.GetComponent<Arrow>()._critical.Play();
            arrow.GetComponent<Arrow>()._Dmg = ArrowDamage * (int)ArcherCriticalDmg;
            arrow.GetComponent<Arrow>().Critical = true;
            Debug.Log("크리티컬");
            //ArcherCriticalOn = true;
        }
        else
        {
            arrow.GetComponent<Arrow>()._Dmg = ArrowDamage ;
            //ArcherCriticalOn = false;
        }
        _lastAttack = 0.0f;
    }

    void DaggerAttack()
    {
        _animator.SetFloat("MoveSpeed", 0);
        int DaggerDamage = Random.Range((int)NinjaDamage / 2, (int)NinjaDamage);
        GameObject Dagger = Instantiate(_waepon);
        Dagger.transform.position = _firePosition.position;
        if (_target != null) Dagger.GetComponent<Dagger>().TargetFind(_target.transform);
        NinjaRand = Random.Range(0, 100);
        if (NinjaRand < NinjaCritical)//크리티컬
        {
            Dagger.GetComponent<Dagger>()._critical.Play();
            Dagger.GetComponent<Dagger>()._Dmg = DaggerDamage * (int)ArcherCriticalDmg;
            Dagger.GetComponent<Dagger>().Critical = true;
        }
        else
        {
            Dagger.GetComponent<Dagger>()._Dmg = DaggerDamage;
        }
        _lastAttack = 0.0f;
    }

    void FireMagicAttack()
    {
        _animator.SetFloat("MoveSpeed", 0);
        int FireDamage = Random.Range((int)WizardDamage / 2, (int)WizardDamage);
        //GameObject FireMagic = Instantiate(_waepon);
        //FireMagic.transform.position = _firePosition.position;
        //FireMagic.GetComponent<FireMagic>().TargetFind(_target.transform);
        WizardRand = Random.Range(0, 100);
        if (WizardRand < WizardCritical)//크리티컬
        {
            GameObject FireMagic1 = Instantiate(_waepon2);
            FireMagic1.transform.position = _firePosition.position;
            if (_target != null) FireMagic1.GetComponent<FireMagic>().TargetFind(_target.transform);
            FireMagic1.GetComponent<FireMagic>()._critical.Play();
            FireMagic1.GetComponent<FireMagic>()._Dmg = FireDamage * (int)ArcherCriticalDmg;
            FireMagic1.GetComponent<FireMagic>().Critical = true;
        }
        else
        {
            GameObject FireMagic = Instantiate(_waepon);
            FireMagic.transform.position = _firePosition.position;
            FireMagic.GetComponent<FireMagic>()._Dmg = FireDamage;
            if (_target != null)
            {
                FireMagic.GetComponent<FireMagic>().TargetFind(_target.transform);
            }
                FireMagic.GetComponent<FireMagic>()._Dmg = FireDamage;
        }
        _lastAttack = 0.0f;
    }

    void AttackTrigger()
    {
        this.transform.LookAt(_target.transform);
        _animator.ResetTrigger("StopAttack");
        _animator.SetTrigger("Attack");
    }
    public void Targeting()
    {
        //==========================================================
        GameObject obj = GameObject.FindGameObjectWithTag("Enemy");
        GameObject obj2 = GameObject.FindGameObjectWithTag("Boss");
        if (obj == null&& obj2 ==null) return; //오류보기싫어서 넣음
        //==========================================================
        if(obj != null) FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        if (obj2 != null) FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Boss"));

        //if (GameObject.FindGameObjectsWithTag("Boss") != null) FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Boss"));
        //else if (GameObject.FindGameObjectsWithTag("Enemy") != null) FoundObjects = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));


        shortDis = Vector3.Distance(gameObject.transform.position, FoundObjects[0].transform.position);
        _target = FoundObjects[0];
        foreach (GameObject found in FoundObjects)
        {
            float dis = Vector3.Distance(gameObject.transform.position, found.transform.position);
            if (dis < shortDis)
            {
                _target = found;
                shortDis = dis;
            }
        }
    }

    public bool IsinRange()
    {
        if (_target == null) return false;
        float dis = Vector3.Distance(_target.transform.position, this.transform.position);
        return dis < _Distance;
    }

    public void AttackSpeeding(int speed)
    {
        switch(speed)
        {
            case 1:
                _attackSpeed = 1.0f;
                _attackDelay = 1.0f;
                break;
            case 2:
                _attackSpeed = 1.5f;
                _attackDelay = 0.5f;
                break;
            case 3:
                _attackSpeed = 2.0f;
                _attackDelay = 0.1f;
                break;

        }

        _animator.SetFloat("AttackSpeed", _attackSpeed);
    }

    public void MovingCheck()
    {
        Vector3 velocity = _agent.velocity;
        Vector3 local = this.transform.InverseTransformDirection(velocity);
        if (local.z < 0.1f)
        {
            moving = false;
        }
        else moving = true;

        if(moving)
        {
            if (local.z < 0.2f)
            {
                _agent.ResetPath();//이동 리셋
            }
        }
    }

    public void PlayerBuff()
    {
        if (CardUI.instance != null)
        {
            AttackSpeed = CardUI.instance._buffAttSpeed;
            ArcherDamage = 10 + CardUI.instance._buffArcherAtt+(_playerLevel*50);
            NinjaDamage = 10 + CardUI.instance._buffNinjaAtt+ (_playerLevel * 50);
            WizardDamage = 20 + CardUI.instance._buffWizardAtt+ (_playerLevel * 50);

            ArcherCritical = CardUI.instance._buffArcherCritical;
            NinjaCritical = CardUI.instance._buffNinjaCritical;
            WizardCritical = CardUI.instance._buffWizardCritical;

            ArcherCriticalDmg = 1.5f+ CardUI.instance._buffArcherCriticalDmg;
            NinjaCriticalDmg = 1.5f+ CardUI.instance._buffNinjaCriticalDmg;
            WizardCriticalDmg = 1.5f+ CardUI.instance._buffWizardCriticalDmg;
        }
    }

    public void PlayerLevel()
    {
        if (_playerLevel == 1) GetComponent<PlayerLv>().Level_1();
        else if(_playerLevel == 2) GetComponent<PlayerLv>().Level_2();
        else if (_playerLevel == 3) GetComponent<PlayerLv>().Level_3();
        else if (_playerLevel == 4) GetComponent<PlayerLv>().Level_4();
        else if (_playerLevel == 5) GetComponent<PlayerLv>().Level_5();
        
    }
}

