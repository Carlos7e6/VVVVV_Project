using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isBack;

    public Sprite[] spritesHeart;

    [SerializeField]
    private int health;
    public static GameManager Instance { get; private set; }

    private GameObject menu;
    private GameObject win;
    private GameObject lose;

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
           Instance = this; 
           DontDestroyOnLoad(this);
           menu = GameObject.Find("Menu");
           lose = GameObject.Find("YouLose");
           win = GameObject.Find("YouWin"); 
        }
    }

    private void Start()
    {
        isBack = false;
        Time.timeScale = 1f;
        menu.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
       
    }
 
    public int SetDmg(int dmg)
    {

        health -= dmg;
        ChangeHeart(health);
        return health;    
    }

    public void EndGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        if (health == 0)
        {
            lose.SetActive(true);
        }
        else
        {
            win.SetActive(true);
        }

    }

    private void ChangeHeart(int health)
    {
        if(health < 0) health = 0;
        Image[] spritesRender = gameObject.GetComponentsInChildren<Image>();
        for(int i = 0; i < spritesRender.Length; i++)
        {
            if (spritesRender[i].name == "Health")
            {
                spritesRender[i].sprite = spritesHeart[health];
            }
        }
    }

    public void RestartGame()
    {
        GameObject.Find("Health").GetComponent<Image>().sprite = spritesHeart[2];
        health = 2;
        Time.timeScale = 1f;
        menu.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(6);
    }
}
