using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public GameObject bulletPrefab;

    public bool flipBasedOnDirection = true;  // Si quieres que el objeto gire basado en la dirección

    void Update()
    {
        // Diferencia de posición entre el objeto y el jugador
        Vector2 direction = player.position - transform.position;

        // Calcula el ángulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica la rotación al objeto
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        // Si quieres que el objeto gire cuando se desplace hacia la izquierda o derecha
        if (flipBasedOnDirection && direction.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (flipBasedOnDirection && direction.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void Start()
    {
        SpawnBullet();
    }
    void SpawnBullet()
    {
        // Crea una instancia de la bala
        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Asigna la dirección de movimiento a la bala
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        bulletScript.SetShooter(this.gameObject);
        bulletScript.SetTargetTransform(player);
    }
}