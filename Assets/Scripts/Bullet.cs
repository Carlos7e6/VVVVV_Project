using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveDirection;
    private GameObject shooter;
    private Transform targetTranform;

    private void Start()
    {
        ResetBullet();
    }

    public void SetShooter(GameObject shooterObj)
    {
        shooter = shooterObj;
    }

    public void SetTargetTransform(Transform targetTrans)
    {
        targetTranform = targetTrans;
    }

    void Update()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D()
    {
        // Cuando la bala colisiona con algo, la reseteamos
        ResetBullet();
    }

    private void ResetBullet()
    {
        // Reiniciamos la posición al shooter

        transform.position = shooter.transform.position;
        Vector2 fireDirection = (targetTranform.position - shooter.transform.position).normalized;
        moveDirection = fireDirection.normalized;
    }
}