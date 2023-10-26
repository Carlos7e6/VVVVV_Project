using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    [SerializeField] private bool isBack;
    [SerializeField] private Color backPortalColor;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer == 3)
        {
            GameManager.Instance.isBack = isBack;
            if (isBack == false)
            {
                if (SceneManager.GetActiveScene().buildIndex != 5)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
                else
                    GameManager.Instance.EndGame();
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1, LoadSceneMode.Single);
            }
        }
    }
    private void Start()
    {
         if(isBack == true)
        {
            GetComponent<SpriteRenderer>().material.SetColor("_Color" ,backPortalColor);
        }
    }
}
