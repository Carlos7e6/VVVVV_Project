using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private float CurrentSpeed;
    public int dmg = 1;
    public GameObject ExplosionFinal;

    private Vector2 moveDirection;
    private GameObject shooter;
    private Transform targetTranform;

    public bool bulletOutRange;

    private void Start()
    {
        ResetBullet();
        CurrentSpeed = speed;
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
       transform.Translate(moveDirection * CurrentSpeed * Time.deltaTime);
    }

    private void ResetBullet()
    {
        // Reiniciamos la posición al shooter
        transform.position = shooter.transform.position;
        Vector2 fireDirection = (targetTranform.position - shooter.transform.position);
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
            if(collider.gameObject.GetComponent<Enemy>().GetDead() == false)
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
        }

        if(collider.gameObject.layer == 6 || collider.gameObject.layer == 3 || collider.gameObject.layer == 11 || collider.gameObject.layer == 7)
        {
            Debug.Log("bom");
            Instantiate(ExplosionFinal, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().Play();
            ResetBullet();
            if (bulletOutRange == true) SetCurrentSpeed(0);
            else if(bulletOutRange == false && CurrentSpeed == 0) SetCurrentSpeed(speed);
        }
    }
    public void SetCurrentSpeed(float speed)
    {
        CurrentSpeed = speed;        
    }
}