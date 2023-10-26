using UnityEngine;
using UnityEngine.SceneManagement;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;  // Referencia al jugador
    public GameObject bulletPrefab;
    private GameObject bulletInstance;

    void Update()
    {
        
        // Diferencia de posición entre el objeto y el jugador
        Vector2 direction = getDirection();

        // Calcula el ángulo en radianes
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Aplica la rotación al objeto
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

    }
    public void SpawnBullet()
    {
        // Crea una instancia de la bala
        if (bulletInstance == null)
        {
            bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }

        // Asigna la dirección de movimiento a la bala
        Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
        bulletScript.bulletOutRange = false;
        bulletScript.SetCurrentSpeed(bulletScript.speed);
        bulletScript.SetShooter(this.gameObject);
        bulletScript.SetTargetTransform(player);
    }

    public void StopSpawnBullet()
    {
        if(bulletInstance != null)
        {
            Bullet bulletScript = bulletInstance.GetComponent<Bullet>();
            bulletScript.bulletOutRange = true;
        }
    }

    public Vector2 getDirection()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return mousePos - transform.position;
        }
        else
        {
            return player.position - transform.position;
        }
    }
}