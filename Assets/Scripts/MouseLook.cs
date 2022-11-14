using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = 0.5f;

    public Vector3 deltaMove;
    public float horizontalMove;
    public float verticalMove;
    public float speed = 2;

    public GameObject player;


    void Start() 
    {
        // Запрещаем указателю выходить за рамки окна игра
        Cursor.lockState = CursorLockMode.Locked; 
    }

    void Update()
    {
        // Получаем координаты мышки
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        // Ограничиваем поворот камеры по оси Y 
        turn.y = Mathf.Clamp(turn.y, -20, 20);

        // Применяем поворот для камеры 
        transform.localRotation = Quaternion.Euler(-turn.y, 0, 0);
        // Применяем поворот для игрока
        player.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        // Применяем движение для игрока
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        deltaMove = new Vector3(horizontalMove, 0, verticalMove) * speed * Time.deltaTime;
        player.transform.Translate(deltaMove);
    }
}
