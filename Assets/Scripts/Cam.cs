using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        StartCoroutine(FindPlayer());

    }

    IEnumerator FindPlayer()
    {
        while (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            transform.LookAt(player.transform.position);
            Debug.Log("Camera pointed at player");
            yield return null;
        }
    }
}
