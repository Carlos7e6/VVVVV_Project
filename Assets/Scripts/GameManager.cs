using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
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
        }
    }

    private void Start()
    {
        isBack = false;
        Time.timeScale = 1f;
        menu.SetActive(false);
       
    }
 
    public int SetDmg(int dmg)
    {

        health -= dmg;
        ChangeHeart(health);
        return health;    
    }

    public void EndGame()
    {
        health = 0;
        Time.timeScale = 0f;
        menu.SetActive(true);

    }

    private void ChangeHeart(int health)
    {
        Image[] spritesRender = gameObject.GetComponentsInChildren<Image>();
        for(int i = 0; i < spritesRender.Length; i++)
        {
            Debug.Log(spritesRender[i].name);
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
        SceneManager.LoadScene(2);
  
    }
}
