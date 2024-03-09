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

    public AudioSource carAudio; // Tham chiếu đến thành phần Audio Source của xe ô tô
    private bool hasPlayedSound = false; // Biến để kiểm tra xem âm thanh đã được phát chưa

    public GameObject pausepanel;
    public GameObject PlayAgainepanel;

    void Start()
    {
        pausepanel.SetActive(false);   
        PlayAgainepanel.SetActive(false);
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausepanel.SetActive(true);
            Time.timeScale = 0.0f;

        }
        if (MainMenuController.instance.star == false)
        {
            return;
        }
        if (isSpeedingUp)
        {
            speedupTimer -= Time.deltaTime;

            if (speedupTimer <= 0f)
            {
                ResetSpeed();
            }
        }
        GameObject[] speedUpObjects = GameObject.FindGameObjectsWithTag("SpeedUp");
        bool allSpeedUpDeactivated = true;
        foreach (GameObject obj in speedUpObjects)
        {
            if (obj.activeSelf)
            {
                allSpeedUpDeactivated = false;
                break;
            }
        }
        // Kiểm tra nếu tất cả các đối tượng "SpeedUp" đã bị deactive và speedUpCount = 0 thì thực hiện hành động của bạn
        if (allSpeedUpDeactivated && speedUpCount == 0)
        {
            PlayAgainepanel.SetActive(true);
            Debug.Log("All SpeedUp objects are deactivated and speedUpCount is 0.");
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        MoveObject(moveDirection);

        if (rb.velocity.magnitude > 0)
        {
            // Kiểm tra nếu âm thanh chưa được phát, bắt đầu phát
            if (!hasPlayedSound)
            {
                carAudio.Play();
                hasPlayedSound = true; // Đánh dấu rằng âm thanh đã được phát
            }
        }
        else
        {
            // Ngừng phát âm thanh khi không còn di chuyển
            carAudio.Stop();
            hasPlayedSound = false; // Đặt lại cờ để cho phép phát lại âm thanh khi di chuyển tiếp
        }
    }

    void MoveObject(Vector2 moveDirection)
    {
        if (rb != null)
        {
            Vector2 movement = moveDirection * moveSpeed * Time.deltaTime;

            rb.velocity = transform.up * movement.y;
/*            carAudio.Play();*/

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
        else if (other.CompareTag("Customer"))
        {
            // Kiểm tra nếu speedUpCount > 0 thì mới trừ
            if (speedUpCount > 0)
            {
                speedUpCount--;
                UpdateSpeedUpCountText();
            }
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
