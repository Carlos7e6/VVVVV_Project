using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 5) gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y +3, -10);
    }
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x,gameObject.transform.position.y, -10);
    }
}
