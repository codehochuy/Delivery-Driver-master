using UnityEngine;

public class Speedup : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float speedupMultiplier = 2f;
    public float speedupDuration = 2f; // Thời gian tăng tốc

    private float currentSpeed;
    private bool isSpeedingUp = false;
    private float speedupTimer;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = normalSpeed;
    }

    private void Update()
    {
        // Kiểm tra xem car có đang tăng tốc không
        if (isSpeedingUp)
        {
            // Nếu đang tăng tốc, giảm thời gian còn lại
            speedupTimer -= Time.deltaTime;

            // Nếu thời gian tăng tốc còn lại <= 0, đặt lại tốc độ
            if (speedupTimer <= 0f)
            {
                ResetSpeed();
            }
        }

        // Di chuyển car theo tốc độ hiện tại
        rb.velocity = new Vector2(currentSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu car chạm vào object có tag "speedup"
        if (other.CompareTag("SpeedUp   "))
        {
            // Tăng tốc nhanh hơn khi chạm vào "speedup"
            isSpeedingUp = true;
            currentSpeed *= speedupMultiplier;
            speedupTimer = speedupDuration;

            // Tạm thời vô hiệu hóa object "speedup"
            other.gameObject.SetActive(false);
        }
    }

    private void ResetSpeed()
    {
        // Đặt lại tốc độ về bình thường
        isSpeedingUp = false;
        currentSpeed = normalSpeed;
    }
}
