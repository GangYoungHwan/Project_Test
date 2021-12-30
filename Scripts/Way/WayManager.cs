using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayManager : MonoBehaviour
{
    public GameObject _way_0;
    public GameObject _way_1;
    public GameObject _way_2;

    public float _startTime;
    private int _rand;
    private float _currentPos;
    int _count;

    public List<GameObject> _wayObjectPool;
    Vector3 _nextWay;
    void Start()
    {
        _currentPos = 0.0f;
        _startTime = 6.5f;
        _rand = 0;
        _count = 0;
        _wayObjectPool = new List<GameObject>();
        GameObject Way_0 = Instantiate(_way_0);
        _wayObjectPool.Add(Way_0);
        _wayObjectPool[_count].transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _startTime += Time.deltaTime;
        if(_startTime >6.5f)
        {
            NextWay();
        }
    }

    void NextWay()
    {
        Vector3 currentEndPosition = _wayObjectPool[_count].transform.Find("EndPoint").gameObject.transform.position;
        int currentRand = _rand;
        
        _rand = Random.Range(1, 3);
        _count++;
        switch(_rand)
        {
            case 1:
                GameObject Way_1 = Instantiate(_way_1);
                _wayObjectPool.Add(Way_1);
                break;
            case 2:
                GameObject Way_2 = Instantiate(_way_2);
                _wayObjectPool.Add(Way_2);
                break;
        }
        if (currentRand == 1) _currentPos += 90.0f;
        else if (currentRand == 2) _currentPos -= 90.0f;

        _wayObjectPool[_count].transform.Rotate(new Vector3(0f, _currentPos, 0f));
        _wayObjectPool[_count].transform.position = currentEndPosition;

        if (_count > 3) Destroy(_wayObjectPool[_count - 4].gameObject);
        _startTime = 0.0f;
    }
}
