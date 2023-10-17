using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera_Effect : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject main_camera;

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == 3)
        {
            main_camera.GetComponent<Transform>().position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
        }
    }



}
