using UnityEngine;

public class Gargoyle : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    [Range(0.1f, 3f)]
    float detectionRadius = 3f;
    [SerializeField]
    float detectionAngle = 45f;
    [SerializeField]
    float rotationAngle = 30f;

    float timer = 5;
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

        if (timer > 0)
        {
            transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = Random.Range(0.3f, 10);
            rotationAngle *= -1;
        }
    }
}
