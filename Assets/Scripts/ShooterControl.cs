using UnityEngine;

public class ShooterControl : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GetComponentInChildren<LookAtPlayer>().SpawnBullet();
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GetComponentInChildren<LookAtPlayer>().StopSpawnBullet();
        }
    }
}
