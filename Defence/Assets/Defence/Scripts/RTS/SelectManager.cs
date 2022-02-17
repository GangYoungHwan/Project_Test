using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

//[RequireComponent(typeof(RectTransform))]
public class SelectManager : MonoBehaviour
{
    public static SelectManager Instance;
    NavMeshAgent _agent;

    public Camera selectCam;
    public RectTransform SelectingBoxRect;

    public Rect SelectingRect;
    public Vector3 SelectingStart;


    public float minBoxSizeBeforeSelect = 10f;
    public float selectUnderMouseTimer = 0.1f;
    public float selectTimer = 0f;

    public bool selecting = false;

    public List<SelectableCharacter> selectableChars = new List<SelectableCharacter>();
    public List<SelectableCharacter> selectedArmy = new List<SelectableCharacter>();

    public float m_DoubleClickSecond = 0.25f;
    public bool m_IsOneClick = false;
    public double m_Timer = 0;

    public void Start()
    {
        Instance = this;
    }
    private void Awake()
    {
        //This assumes that the manager is placed on the image used to select
        if (!SelectingBoxRect) {
            SelectingBoxRect = GetComponent<RectTransform>();
        }

        //Searches for all of the objects with the selectable character script
        //Then converts to list
        //SelectableCharacter[] chars = FindObjectsOfType<SelectableCharacter>();
        //for (int i = 0; i <= (chars.Length - 1); i++) {
        //    selectableChars.Add(chars[i]);
        //}
    }

    void Update()
    {
        if (SelectingBoxRect == null) return;

        if (m_IsOneClick && ((Time.time - m_Timer) > m_DoubleClickSecond))
        {
            Debug.Log("One Click");
            m_IsOneClick = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject()) ReSelect2();
            if (!m_IsOneClick)//원클릭
            {
                SelectingStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
                SelectingBoxRect.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
                SelectableCharacter[] chars = FindObjectsOfType<SelectableCharacter>();
                for (int i = 0; i <= (chars.Length - 1); i++)
                {
                    selectableChars.Add(chars[i]);
                }
                m_Timer = Time.time;
                m_IsOneClick = true;
            }
            else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond))
            {
                DoubleClick();
                Debug.Log("Double Click");
                m_IsOneClick = false;
            }
        }
        else if (Input.GetMouseButtonUp(0)) selectTimer = 0f;

        else selecting = false;
        selecting = Input.GetMouseButton(0);
        if (selecting)
        {
            SelectingArmy();
            selectTimer += Time.deltaTime;
        
            //Only check if there is a character under the mouse for a fixed time
            if (selectTimer <= selectUnderMouseTimer) {
                CheckIfUnderMouse();
            }
        }
        else SelectingBoxRect.sizeDelta = new Vector2(0, 0);
        if (Moving() == true) return;
        /*
        //if (Input.GetMouseButtonDown(0))
        //{
        //ReSelect();
        //SelectingStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //SelectingBoxRect.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //SelectableCharacter[] chars = FindObjectsOfType<SelectableCharacter>();
        //for (int i = 0; i <= (chars.Length - 1); i++)
        //{
        //    selectableChars.Add(chars[i]);
        //}


        //if (!m_IsOneClick)
        //{
        //    //ReSelect();
        //    //ReSelect2();
        //    SelectingStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //    SelectingBoxRect.anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //    SelectableCharacter[] chars = FindObjectsOfType<SelectableCharacter>();
        //    for (int i = 0; i <= (chars.Length - 1); i++)
        //    {
        //        selectableChars.Add(chars[i]);
        //    }
        //    m_Timer = Time.time;
        //    m_IsOneClick = true;
        //}
        //else if (m_IsOneClick && ((Time.time - m_Timer) < m_DoubleClickSecond))
        //{
        //    DoubleClick();
        //    Debug.Log("Double Click");
        //    m_IsOneClick = false;
        //
        //}

        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    selectTimer = 0f;
        //}

        //selecting = Input.GetMouseButton(0);
        //
        //if (selecting)
        //{
        //    SelectingArmy();
        //    selectTimer += Time.deltaTime;
        //
        //    //Only check if there is a character under the mouse for a fixed time
        //    if (selectTimer <= selectUnderMouseTimer) {
        //        CheckIfUnderMouse();
        //    }
        //}
        //else SelectingBoxRect.sizeDelta = new Vector2(0, 0);
        //if (Moving() == true) return;
        */
    }

    //Resets what is currently being selected
    void ReSelect()
    {
        for (int i = 0; i <= (selectedArmy.Count - 1); i++)
        {
            selectedArmy[i].TurnOffSelector();
            selectedArmy.Remove(selectedArmy[i]);
        }
    }

    void ReSelect2()
    {
        foreach (SelectableCharacter soldier in selectableChars)
        {
            soldier.TurnOffSelector();
        }
        for (int i = 0; i <= (selectableChars.Count - 1); i++)
        {
            selectableChars.Remove(selectableChars[i]);
        }
    }

    //Does the calculation for mouse dragging on screen
    //Moves the UI pivot based on the direction the mouse is going relative to where it started
    //Update: Made this a bit more legible
    void SelectingArmy()
    {
        Vector2 _pivot = Vector2.zero;
        Vector3 _sizeDelta = Vector3.zero;
        Rect _rect = Rect.zero;

        //Controls x's of the pivot, sizeDelta, and rect
        if (-(SelectingStart.x - Input.mousePosition.x) > 0) 
        {
            _sizeDelta.x = -(SelectingStart.x - Input.mousePosition.x);
            _rect.x = SelectingStart.x;
        } 
        else 
        {
            _pivot.x = 1;
            _sizeDelta.x = (SelectingStart.x - Input.mousePosition.x);
            _rect.x = SelectingStart.x - SelectingBoxRect.sizeDelta.x;
        }

        //Controls y's of the pivot, sizeDelta, and rect
        if (SelectingStart.y - Input.mousePosition.y > 0) 
        {
            _pivot.y = 1;
            _sizeDelta.y = SelectingStart.y - Input.mousePosition.y;
            _rect.y = SelectingStart.y - SelectingBoxRect.sizeDelta.y;
        } 
        else 
        {
            _sizeDelta.y = -(SelectingStart.y - Input.mousePosition.y);
            _rect.y = SelectingStart.y;
        }

        //Sets pivot if of UI element
        if (SelectingBoxRect.pivot != _pivot)
            SelectingBoxRect.pivot = _pivot;

        //Sets the size
        SelectingBoxRect.sizeDelta = _sizeDelta;

        //Finished the Rect set up then set rect
        _rect.height = SelectingBoxRect.sizeDelta.x;
        _rect.width = SelectingBoxRect.sizeDelta.y;
        SelectingRect = _rect;

        //Only does a select check if the box is bigger than the minimum size.
        //While checking it messes with single click
        if (_rect.height > minBoxSizeBeforeSelect && _rect.width > minBoxSizeBeforeSelect)
        {
            CheckForSelectedCharacters();
        }
    }

    void CheckForSelectedCharacters()//
    {
        foreach (SelectableCharacter soldier in selectableChars)
        {
            if (soldier != null)
            {
                Vector2 screenPos = selectCam.WorldToScreenPoint(soldier.transform.position);
                if (SelectingRect.Contains(screenPos))
                {
                    if (!selectedArmy.Contains(soldier))
                        selectedArmy.Add(soldier);

                    soldier.TurnOnSelector();

                }
                else if (!SelectingRect.Contains(screenPos))
                {
                    soldier.TurnOffSelector();

                    if (selectedArmy.Contains(soldier))
                        selectedArmy.Remove(soldier);
                }
            }
        }
    }


    void CheckIfUnderMouse()
    {
        RaycastHit hit;
        Ray ray = selectCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100f)) {
            if (hit.transform != null) {
                SelectableCharacter selectChar = hit.transform.gameObject.GetComponentInChildren<SelectableCharacter>();
                if (selectChar != null && selectableChars.Contains(selectChar))
                {
                    selectedArmy.Add(selectChar);
                    selectChar.TurnOnSelector();
                }
            }
        }
    }

    public bool Moving()
    {
        RaycastHit hit;
        GameObject _target = null;
        if (Physics.Raycast(GetMouseRay(), out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(1))
            {
                foreach (SelectableCharacter soldier in selectableChars)
                {
                    if (soldier != null)
                    {
                        if (soldier.selectImage.enabled)
                        {
                            _agent = soldier.GetComponentInParent<NavMeshAgent>();
                            _agent.isStopped = false;
                            _agent.destination = hit.point;
                        }
                    }
                }
            }
            return true;
        }
        return false;
    }
    public bool DoubleClick()
    {
        RaycastHit hit;
        GameObject _target = null;
        
        if (Physics.Raycast(GetMouseRay(), out hit, 100.0f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //_target = hit.collider.gameObject.transform.GetChild(0).gameObject;
                _target = hit.collider.transform.GetChild(0).gameObject;
                Debug.Log(_target.tag);
                foreach (SelectableCharacter soldier in selectableChars)
                {
                    if (soldier != null)
                    {
                        if (_target.tag == soldier.tag)
                        {
                            soldier.TurnOnSelector();
                        }
                    }
                }
            }
            return true;
        }
        return false;
    }
    private Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
