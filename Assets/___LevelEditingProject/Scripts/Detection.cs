using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Detection : MonoBehaviour
{
    public bool playerdetected = false;
    [SerializeField] float fov = 60.0f;
    [SerializeField] Transform player;
    [SerializeField] float inRange = 5f;
    [SerializeField] Light light;
    float distToPlayer = 0f;
    float angle;


    void Update()
    {
        light.spotAngle = fov;
        light.range = inRange;
        distToPlayer = Vector3.Distance(transform.position, player.position);
        angle = Vector3.Angle(transform.forward, player.position - transform.position);
        if ((angle < fov) && (distToPlayer < inRange) && !playerdetected)
        {
            playerdetected = true;
            Debug.Log("Detected...");
            SceneManager.LoadScene(0);
        }
    }
}