using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int dmg;
    [SerializeField]
    private int speed;
    [SerializeField]
    private Vector3[] positions;
    private int index;

    private AnimationBehaviour anim;
    private bool isFlippedX;


    [SerializeField] private bool isFlippedY;
    [SerializeField] public bool isRunning;
    private bool isDead = false;
    public bool Fly;

    private void Start()
    {
        index = 0;
        anim = GetComponent<AnimationBehaviour>();
        anim.FlipCharacter(isFlippedX, isFlippedY);
        GetComponent<Animator>().SetBool("isRunning",isRunning);    
    }

    private void FixedUpdate() 
    {
        if(isRunning == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, positions[index], speed * Time.deltaTime);
            anim.FlipCharacter(isFlippedX, isFlippedY);
        }
    }

    public void SetDead()
    {
        GetComponent<AudioSource>().Play();
        isDead = true;
        if (Fly != false) Destroy(GetComponent<PolygonCollider2D>());
    }

    public bool GetDead()
    {
        return isDead;
    }

    private void Update()
    {
        if (isRunning == true)
        {
            if (transform.position == positions[index])
            {
                if (index == positions.Length - 1)
                {
                    index = 0;
                }
                else
                {
                    index++;
                }
            }
            else if (transform.position.x > positions[index].x)
            {
                isFlippedX = true;
            }
            else
            {
                isFlippedX = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 3)
        {
            if(isDead != true)
            {
                if (GameManager.Instance.SetDmg(dmg) <= 0)
                {
                    GameManager.Instance.EndGame();
                }
            }
        }
        else if(collider.gameObject.layer == 6 && isDead == true)
        {
            Destroy(GetComponent<PolygonCollider2D>());
            try
            {
                Debug.Log("Enemigo cayendo");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
            catch { }
        }
        
    }
  
}
