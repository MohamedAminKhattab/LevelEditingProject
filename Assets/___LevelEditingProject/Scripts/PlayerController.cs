using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float playerSpeed;
    [SerializeField]
    float rotaionSpeed;
    [SerializeField] PlayableDirector playableDirector;
    [SerializeField] GameObject dolyCart;

    Animator playerAnimator;
    float horizontal;
    float verical;
    float gravityValue = -9.81f;
    Vector3 playerVelocity;

    bool isMoving;
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

        Vector3 move = new Vector3(0, 0, verical) ;
        Vector3 rotation = new Vector3(0, horizontal,0 );

        move = characterController.transform.TransformDirection(move);
        characterController.Move(move * Time.deltaTime * playerSpeed );
        characterController.transform.Rotate( rotation * rotaionSpeed * Time.deltaTime);

        isMoving = horizontal != 0 || verical != 0;
        playerAnimator.SetBool("IsWalking", isMoving);

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);


    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Winzone"))
        {
            //todo cinemachine flyover
            Debug.Log("won");
            dolyCart.GetComponent<CinemachineDollyCart>().m_Speed = 2;


            playableDirector.Play();
            

        }
    }
}
