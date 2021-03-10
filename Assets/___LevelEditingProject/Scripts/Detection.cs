using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public bool playerdetected = false;
    [SerializeField] float fov = 60.0f;
    [SerializeField] Transform player;
    [SerializeField] float inRange = 5f;
    float distToPlayer = 0f;
    float angle;

    void Update()
    {
        //Vector3 Enemyforward = transform.forward;
        distToPlayer = Vector3.Distance(transform.position,  player.position);
        angle = Vector3.Angle(transform.forward, (player.position - transform.position));
        if ((angle < fov) && (distToPlayer < inRange) && !playerdetected)
        {
            playerdetected = true;
            Debug.Log("Detected...");
        }
    }
}