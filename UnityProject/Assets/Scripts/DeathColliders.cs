using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathColliders : MonoBehaviour
{
    private void OnTriggerEnter2D()
    {
        GameManager.Instance.SetDmg(2);
        GameManager.Instance.EndGame();
    }
}
