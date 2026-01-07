using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float fireRate = 0.2f;

    public bool isFiring;
    Coroutine fireCoroutine;

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FiringContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator FiringContinuously()
    {
        while (true)
        {
            GameObject projectTile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectTile.GetComponent<Rigidbody2D>().linearVelocityY = projectileSpeed;

            Destroy(projectTile, projectileLifeTime);

            yield return new WaitForSeconds(fireRate);
        }
    }
}
