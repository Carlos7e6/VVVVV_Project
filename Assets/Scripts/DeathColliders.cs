using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathColliders : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        Debug.Log("muerte");
        GameManager.Instance.EndGame();
    }
}
