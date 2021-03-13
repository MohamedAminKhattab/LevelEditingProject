using UnityEngine;
using UnityEngine.SceneManagement;

public class Gargoyle : MonoBehaviour
{
    [SerializeField]
    Transform player;
    [SerializeField]
    [Range(0.1f, 3f)]
    float detectionRadius = 3f;
    [SerializeField]
    [Range(10f, 180f)]
    float detectionAngle = 45f;
    [SerializeField]
    [Range(10, 180f)]
    float rotationAngle = 30f;
    [SerializeField] Light light;

    float timer = 5;
    //Material playerMat;

    Vector3 dirToPlayer;
    float dist;
    float dotValue;
    float angle;

    void Start()
    {
        //playerMat = player.GetComponent<SkinnedMeshRenderer>().material;
        light = transform.GetComponentInChildren<Light>();
    }

    void Update()
    {
        light.spotAngle = detectionAngle;
        light.range = detectionRadius;
        dist = Vector3.Distance(transform.position, player.position);
        if (timer > 0)
        {
            transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
            timer -= Time.deltaTime;
        }
        else
        {
            timer = Random.Range(0.3f, 10);
            //rotationAngle = Random.Range(-180, 180);
            rotationAngle *= -1;
        }
        if (dist < detectionRadius)
        {
            dirToPlayer = (player.position - transform.position).normalized;
            dotValue = Vector3.Dot(dirToPlayer, transform.forward);

            angle = Mathf.Acos(dotValue) * Mathf.Rad2Deg;
            if (angle < detectionAngle / 2)
            {
                //playerMat.color = Color.red;
                SceneManager.LoadScene(0);
                // TODO: Payer is dead here...
            }
            // TODO: else block To be removed
            //else
            //{
            //    playerMat.color = Color.white;
            //}
        }
        // TODO: else block To be removed
        //else
        //{
        //    playerMat.color = Color.white;
        //}
    }
}