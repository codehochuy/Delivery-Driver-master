using UnityEngine;

public class CarController : MonoBehaviour
{
    public Color defaultColor;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Package")
        {
            Color packageColor = collision.gameObject.GetComponent<SpriteRenderer>().color;
            spriteRenderer.color = packageColor;
        }
    }
}