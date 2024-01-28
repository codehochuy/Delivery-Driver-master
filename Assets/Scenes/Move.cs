using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 100f;
    public float speedupMultiplier = 2f;
    public float speedupDuration = 2f;
    private Rigidbody2D rb;
    private bool isSpeedingUp = false;
    private float speedupTimer;
    private int speedUpCount = 0;
    public TMP_Text speedUpCountText; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D is missing on the game object.");
        }

        if (speedUpCountText == null)
        {
            Debug.LogError("TextMeshPro Text is not assigned for displaying SpeedUp count.");
        }
        else
        {
            UpdateSpeedUpCountText();
        }
    }

    void Update()
    {
        if (isSpeedingUp)
        {
            speedupTimer -= Time.deltaTime;

            if (speedupTimer <= 0f)
            {
                ResetSpeed();
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        MoveObject(moveDirection);

    }

    void MoveObject(Vector2 moveDirection)
    {
        if (rb != null)
        {
            Vector2 movement = moveDirection * moveSpeed * Time.deltaTime;

            rb.velocity = transform.up * movement.y;

            if (Input.GetKey(KeyCode.D))
            {
                rb.angularVelocity = -rotationSpeed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                rb.angularVelocity = rotationSpeed;
            }
            else
            {
                rb.angularVelocity = 0f;
            }
        }
        else
        {
            Debug.LogError("Rigidbody2D is missing on the game object.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedUp"))
        {
            StartSpeedUp();
            other.gameObject.SetActive(false);
            speedUpCount++;
            UpdateSpeedUpCountText();
        }
    }

    void StartSpeedUp()
    {
        isSpeedingUp = true;
        speedupTimer = speedupDuration;
        moveSpeed *= speedupMultiplier;
    }

    void ResetSpeed()
    {
        isSpeedingUp = false;
        moveSpeed /= speedupMultiplier;
    }

    void UpdateSpeedUpCountText()
    {
      
        speedUpCountText.text = "Count: " + speedUpCount.ToString();
    }
}
