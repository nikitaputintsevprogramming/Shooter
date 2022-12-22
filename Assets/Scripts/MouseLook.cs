using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 2f;

    public Vector3 deltaMove;
    public float horizontalMove;
    public float verticalMove;
    public float speed = 2;

    public GameObject player;
    public Animator PlayerAnimator;
    public MobileController _mobileControllerMovement;
    public MobileController _mobileControllerRotate;


    void Start() 
    {
        // Запрещаем указателю выходить за рамки окна игра
        // Cursor.lockState = CursorLockMode.Locked; 

        PlayerAnimator = player.GetComponent<Animator>();
        _mobileControllerMovement = GameObject.FindGameObjectWithTag("Joystick_BG").GetComponent<MobileController>();
        _mobileControllerRotate = GameObject.FindGameObjectWithTag("Joystick_BG_Rotate").GetComponent<MobileController>();
    }

    void Update()
    {
        // Получаем координаты мышки
        if(Input.GetAxis("Mouse X") != 0)
        {
            turn.x += Input.GetAxis("Mouse X") * sensitivity;
        }
        else 
        {
            turn.x += _mobileControllerRotate.Horizontal() * sensitivity;
        }

        if(Input.GetAxis("Mouse Y") != 0)
        {
            turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        }
        else 
        {
            turn.y += _mobileControllerRotate.Vertical() * sensitivity;
        }

        // Ограничиваем поворот камеры по оси Y 
        turn.y = Mathf.Clamp(turn.y, -20, 20);

        // Применяем поворот для камеры 
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        // Применяем поворот для игрока
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        // Применяем движение для игрока
        horizontalMove = _mobileControllerMovement.Horizontal();
        verticalMove = _mobileControllerMovement.Vertical();
        deltaMove = new Vector3(horizontalMove, 0, verticalMove) * speed * Time.deltaTime;
        player.transform.Translate(deltaMove); 

        PlayerController();     
    }

    void PlayerController()
    {
        if(verticalMove > 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                PlayerAnimator.SetInteger("Move", 2);
                speed = 4;
            }
            
            else 
            {
                PlayerAnimator.SetInteger("Move", 1);
                speed = 2;
            }
        }

        else if(verticalMove < 0)
        {
            PlayerAnimator.SetInteger("Move", -1);
            speed = 2;
        }

        else
        {
            PlayerAnimator.SetInteger("Move", 0);
            speed = 0;
        }
    }
}
