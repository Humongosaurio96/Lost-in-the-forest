using UnityEngine;

public class Viento : MonoBehaviour
{
    public Vector2 windDirection = new Vector2(1, 0); // Dirección del viento (por ejemplo, hacia la derecha)
    public float windStrength = 5f; // Intensidad del viento

    private void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = other.attachedRigidbody;
        if (rb != null && other.CompareTag("Player"))
        {
            rb.AddForce(windDirection.normalized * windStrength, ForceMode2D.Force);
        }
    }
}