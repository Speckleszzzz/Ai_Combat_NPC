using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Enemy Data")]
    public GameObject enemy;

    [Header("FireBall Data")]
    public GameObject fireBallPreFab;
    public float fireBallSpeed;

    [Header("Player Data")]
    public GameObject player;

    void Start()
    {
        ShootFireBall();
    }

    void ShootFireBall()
    {
        GameObject temp = Instantiate(fireBallPreFab, new Vector3(enemy.transform.position.x - 1.2f, enemy.transform.position.y, enemy.transform.position.z), enemy.transform.rotation);
        temp.AddComponent<FireBall>();
        temp.GetComponent<FireBall>().player = player;

        Invoke("ShootFireBall", 4f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached me");
        }
    }
}
