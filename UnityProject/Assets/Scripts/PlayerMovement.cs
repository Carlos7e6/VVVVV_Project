using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float currentSpeed;
    private float speedUp;

    private bool isRunning;
    private bool isFlying;
    private bool isFlipedX;
    private bool isFlipedY;

    private AnimationBehaviour anim;

    public float _speed;
    public int health;

    [SerializeField] private Vector2 positionBackToSpawn;


    void Start()
    {
        currentSpeed = 0;
        speedUp = -15;
        isFlipedX = false;
        isFlipedY = false;
        isRunning =  false;
        isFlying = true;
        anim = GetComponent<AnimationBehaviour>();

        if(GameManager.Instance.isBack) transform.position = positionBackToSpawn;
    }

    private void FixedUpdate()
    {

        anim.Move(currentSpeed, speedUp, isRunning);
        anim.FlipCharacter(isFlipedX,isFlipedY);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed = _speed * -1;
            isFlipedX =true;
            isRunning = true;

            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            currentSpeed = _speed;
            isFlipedX = false;
            isRunning = true;
        }
        else
        {
            currentSpeed = 0;
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isFlying == false)
            {
                GetComponent<AudioSource>().Play();
                speedUp *= -1;
                isFlipedY = !isFlipedY;
                isFlying = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            isFlying = false;
        }
    
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isFlying = true;
        }
    }
}
