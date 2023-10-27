using UnityEngine;

public class AnimationBehaviour : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _sprRndr;
    private Animator _animator;

    public AnimationBehaviour()
    {
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _sprRndr = GetComponent <SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float currentSpeed, float speedUp, bool isRunning)
    {
        if(GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static)
        {
            _rb.velocity = new Vector2(1 * currentSpeed, speedUp);
            _animator.SetBool("isRunning", isRunning);
        }
    }

    public void FlipCharacter(bool isFlipedX, bool isFlipedY)
    {
        if(isFlipedY == true)
        {
            GetComponent<Transform>().localScale = new Vector3(1,-1,1);
        }
        else
        {
            GetComponent<Transform>().localScale = new Vector3(1, 1, 1);
        }
        _sprRndr.flipX = isFlipedX;
        //_sprRndr.flipY = isFlipedY;
    }
}
