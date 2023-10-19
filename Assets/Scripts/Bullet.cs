using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int dmg = 1;
    public GameObject ExplosionFinal;

    private Vector2 moveDirection;
    private GameObject shooter;
    private Transform targetTranform;

    private void Start()
    {
        ResetBullet();
    }

    //Seteamos en el padre cual es el shooter
    public void SetShooter(GameObject shooterObj)
    {
        shooter = shooterObj;
    }

    //Seteamos en el padre cual es el objetivo
    public void SetTargetTransform(Transform targetTrans)
    {
        targetTranform = targetTrans;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void ResetBullet()
    {
        // Reiniciamos la posición al shooter
        transform.position = shooter.transform.position;
        Vector2 fireDirection = (targetTranform.position - shooter.transform.position).normalized;
        moveDirection = fireDirection.normalized;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 3)
        {
            if (GameManager.Instance.SetDmg(dmg) == 0)
            {
                GameManager.Instance.EndGame();
            }
        }
        else if(collider.gameObject.layer == 7)
        {
            collider.gameObject.GetComponent<Enemy>().isRunning = false;
            collider.gameObject.GetComponent<Animator>().SetBool("isRunning", false);
            collider.gameObject.GetComponent<Animator>().SetBool("isDead", true);
            collider.gameObject.GetComponent<Enemy>().SetDead();

            try
            {
                collider.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
            }
            catch { }
        }

        Instantiate(ExplosionFinal, transform.position, Quaternion.identity);
        ResetBullet();
    }
}