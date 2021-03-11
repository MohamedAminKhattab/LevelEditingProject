using UnityEngine;

public class Gargoyle : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    float detectionRadius = 3f;
    [SerializeField]
    float detectionAngle = 45f;
    Material playerMat;

    Vector3 dirToPlayer;
    float dist;
    float dotValue;
    float angle;
    void Start()
    {
        if (player != null)
        {
            playerMat = player.GetComponent<MeshRenderer>().material;
        }
    }

    void Update()
    {

        dist = Vector3.Distance(transform.position, player.position);
        if (dist < detectionRadius)
        {
            dirToPlayer = (player.position - transform.position).normalized;
            dotValue = Vector3.Dot(dirToPlayer, transform.forward);

            angle = Mathf.Acos(dotValue) * Mathf.Rad2Deg;
            if (angle < detectionAngle / 2)
            {
                playerMat.color = Color.red;
            }
            else
            {
                playerMat.color = Color.white;
            }

        }
        else
        {
            playerMat.color = Color.white;
        }

    }
}
