using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public GameObject bulletPrefab;
    private GameObject bulletInstance;

    void Update()
    {
        // Diferencia de posici�n entre el objeto y el jugador
        Vector2 direction = player.position - transform.position;

        // Calcula el �ngulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica la rotaci�n al objeto
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }
    public void SpawnBullet()
    {
        // Crea una instancia de la bala
        bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Asigna la direcci�n de movimiento a la bala
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        bulletScript.SetShooter(this.gameObject);
        bulletScript.SetTargetTransform(player);
    }

    public void StopSpawnBullet()
    {
        Destroy(bulletInstance);
    }
}