using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;

    Animator playerAnimator;
    float horizontal;
    float verical;
    CharacterController characterController; 
    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        verical = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horizontal, 0, verical);
        characterController.Move(move * Time.deltaTime * playerSpeed);
        if(horizontal!=0 || verical!=0)
        {
            Debug.Log(" play ");
            playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }

    }
}
