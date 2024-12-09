using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Переменные
    private Animator animator;
    private Rigidbody2D rb;

    public float speed = 5f; // Скорость движения
    private Vector2 movement;

    void Start()
    {
        // Инициализация
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Считывание ввода от пользователя
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Проверка состояния движения
        bool isWalking = movement.magnitude > 0;
        animator.SetBool("isWalking", isWalking); // Передача параметра в аниматор

        // Поворот персонажа
        if (movement.x < 0)
        {
            // Движение влево: отразить персонажа по оси X
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (movement.x > 0)
        {
            // Движение вправо: вернуть нормальный масштаб
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        // Перемещение персонажа
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
