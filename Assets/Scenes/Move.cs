using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển
    public float rotationSpeed = 100f; // Tốc độ xoay
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        // Lấy thành phần Rigidbody2D của đối tượng
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on the game object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Lấy input từ bàn phím
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Tính toán hướng di chuyển
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        // Di chuyển và xoay đối tượng
        MoveObject(moveDirection);

    }
    void MoveObject(Vector2 moveDirection)
    {
        // Kiểm tra xem có tồn tại Rigidbody2D hay không
        if (rb != null)
        {
            // Tính toán vector di chuyển
            Vector2 movement = moveDirection * moveSpeed * Time.deltaTime;

            // Áp dụng di chuyển vào velocity của đối tượng theo hướng đầu mũi
            rb.velocity = transform.up * movement.y;

            // Nếu nhấn nút D, thực hiện xoay về phải
            if (Input.GetKey(KeyCode.D))
            {
                // Áp dụng lực xoay về phải
                rb.angularVelocity = -rotationSpeed;
            }
            // Nếu nhấn nút A, thực hiện xoay về trái
            else if (Input.GetKey(KeyCode.A))
            {
                // Áp dụng lực xoay về trái
                rb.angularVelocity = rotationSpeed;
            }
            else
            {
                // Ngưng lực xoay khi không nhấn nút
                rb.angularVelocity = 0f;
            }
        }
        else
        {
            Debug.LogError("Rigidbody2D is missing on the game object.");
        }
    }
}
