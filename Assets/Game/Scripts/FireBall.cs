using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject player;
    [SerializeField] Vector3 playerPosition;
    [SerializeField] Vector3 fireBallPosition;
    [SerializeField] float speed = 4f;

    void Start()
    {
        playerPosition = player.transform.position;
    }

    void Update()
    {
        if (playerPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
            fireBallPosition = this.transform.position;

            if (fireBallPosition == playerPosition)
            {
                Destroy(this.gameObject);
                Debug.Log("Completely Missed");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            Debug.Log("Player is hit");
        }
    }
}
