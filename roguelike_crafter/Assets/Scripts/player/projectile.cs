using UnityEngine;

public class projectile : MonoBehaviour
{
    public float projectileSpeed;
    private long damage;

    private void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void setDamage(long newDmg)
    {
        damage = newDmg;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemy"))
        {
            // Debug.Log(damage);
            other.transform.GetComponent<enemyHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
