using UnityEngine;

public class ColisionDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount = 1; 

    private void OnTriggerEnter(Collider other)
    {
       
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount);
        }
    }
}
