using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public long health;
    public Observer manager;

    public void TakeDamage(long damageToInflict)
    {
        health -= damageToInflict;

        if (health <= 0)
        {
            manager.enemyHasDied(transform.position);
            Destroy(gameObject);
        }
        
        // update enemy health
    }
}
