using UnityEngine;

public class Heath : MonoBehaviour
{
    [SerializeField] int heath = 50;
    DamageDealer damageDealer;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        heath -= damage;
        CheckAlive();
    }

    void CheckAlive()
    {
        if (heath <= 0)
        {
            Destroy(gameObject);
        }
    }
}
