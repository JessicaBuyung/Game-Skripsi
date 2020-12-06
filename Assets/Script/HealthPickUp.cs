using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    PlayerHealth playerHealth;

    public float healthBonus = 1;

    void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (playerHealth.curHealth < playerHealth.maxHealth)
        {
            Destroy(gameObject);
            playerHealth.healthBar.value = playerHealth.healthBar.value + healthBonus;
        }
    }
}