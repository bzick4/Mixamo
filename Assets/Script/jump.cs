using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
   private CharacterController _controller;
    private Vector3 _velocity;
    private bool isGrounded;

    public float jumpHeight = 2f; // Высота прыжка
    public float gravity = -9.8f; // Сила притяжения
    public float moveSpeed = 5f; // Скорость движения

    void Update()
    {
        // Проверяем, касается ли персонаж земли
        isGrounded = _controller.isGrounded;

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f; // Держим персонажа "на земле"
        }

        // Обрабатываем ввод для движения
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        _controller.Move(move * moveSpeed * Time.deltaTime);

        // Обрабатываем прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Применяем гравитацию
        _velocity.y += gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
