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
    private GameObject fmenu;
    private GameObject WinOrLoseText;
    private GameObject WinOrLoseMenu;

    private bool SetPause = false;

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
           fmenu = GameObject.Find("FirstMenu");
            WinOrLoseText = GameObject.Find("WinOrLoseText");
            WinOrLoseMenu = GameObject.Find("WinOrLoseMenu");
        }
    }

    private void Start()
    {
        isBack = false;
        Time.timeScale = 1f;


        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            fmenu.SetActive(false);
            menu.SetActive(false);
        }
        else
        {
            fmenu.SetActive(true);
            menu.SetActive(true);
        }

        WinOrLoseMenu.SetActive(false);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && health >0)
        {
            if (WinOrLoseMenu.active == false)
            {
                menu.SetActive(true);
                WinOrLoseMenu.SetActive(true);
                WinOrLoseText.GetComponent<Text>().text = "PAUSE";
                Time.timeScale = 0f;
            }
            else
            {
                menu.SetActive(false);
                WinOrLoseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
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
        if (health <= 0)
        {
            Debug.Log("Derrota");
            SetWinOrLoseText(false);
        }
        else
        {
            Debug.Log("Victoria");
            SetWinOrLoseText(true);
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

    private void SetWinOrLoseText(bool isWin)
    {
        if(isWin == true)
        {
            WinOrLoseText.GetComponent<Text>().text = "¡Has ganado!";
        }
        else
        {
            WinOrLoseText.GetComponent<Text>().text = "¡Has perdido!";
        }
        WinOrLoseMenu.SetActive(true);
    }

    public void RestartStats()
    {
        GameObject.Find("Health").GetComponent<Image>().sprite = spritesHeart[2];
        health = 2;
        Time.timeScale = 1f;
        Debug.Log("RestartStats");
    }

    public void SetSceneLoad(int x)
    {

        if(x == -1) Application.Quit();
        else if (x == 0)
        {
            Debug.Log("Charging menu");
            WinOrLoseMenu.SetActive(false);
            fmenu.SetActive(true);
            SceneManager.LoadScene(x);
          
        }
        else
        {
            isBack = false;
            RestartStats();
            menu.SetActive(false);
            fmenu.SetActive(false);
            SceneManager.LoadScene(x); 
        }   
    }

}
