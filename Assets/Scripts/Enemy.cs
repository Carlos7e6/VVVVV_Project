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

    private void Start()
    {
        index = 0;
        anim = GetComponent<AnimationBehaviour>();
    }

    private void FixedUpdate() 
    {
        transform.position = Vector2.MoveTowards(transform.position, positions[index], speed * Time.deltaTime);
        anim.FlipCharacter(isFlippedX, isFlippedY);
    }

    private void Update()
    {

        if(transform.position == positions[index])
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
        else if(transform.position.x > positions[index].x)
        {
            isFlippedX = true;
        }
        else
        {
            isFlippedX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 3)
        {
            if(GameManager.Instance.SetDmg(dmg) == 0)
            {
                GameManager.Instance.EndGame();
            }
        }
        
    }
  
}
