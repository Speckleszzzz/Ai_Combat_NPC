using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float xAxis;
    [SerializeField] float zAxis;

    void Update()
    {
        xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(xAxis,0f,zAxis);
    }

}
