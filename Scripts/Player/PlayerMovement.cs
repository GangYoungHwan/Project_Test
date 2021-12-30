using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private bool turnLeft, trunRight;
    public float _speed = 20.0f;

    private Vector3 _currentPos;

    private CharacterController _myCharacterController;
    void Start()
    {
        _myCharacterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        _currentPos = this.transform.position;
        turnLeft = Input.GetKeyDown(KeyCode.A);
        trunRight = Input.GetKeyDown(KeyCode.D);

        if(turnLeft)
        {
            transform.Rotate(new Vector3(0f, -90f, 0f));
        }
        else if(trunRight)
        {
            transform.Rotate(new Vector3(0f, 90f, 0f));
        }
        _myCharacterController.SimpleMove(new Vector3(0f, 0f, 0f));
        _myCharacterController.Move(transform.forward * _speed * Time.deltaTime);

        if(_currentPos == this.transform.position)
        {
            Debug.Log("게임오버");
            SceneManager.LoadScene("GameOver");
        }
    }
    
}
