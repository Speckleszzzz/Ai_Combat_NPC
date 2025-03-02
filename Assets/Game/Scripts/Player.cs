using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : Agent
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 5f;

    [SerializeField] float xAxis;
    [SerializeField] float zAxis;

    [Header("Enemy Data")]
    [SerializeField] private Transform enemyTransform;

    public override void OnEpisodeBegin()
    {
        transform.position = new Vector3(-20f, 1f, 0f);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position);
        sensor.AddObservation(enemyTransform.position);
    }


    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];

        transform.position += new Vector3(moveX, 0f, moveZ) * moveSpeed * Time.deltaTime;
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continousActions = actionsOut.ContinuousActions;
        continousActions[0] = Input.GetAxis("Horizontal");
        continousActions[1] = Input.GetAxis("Vertical");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyShooter>(out EnemyShooter enemyShooter))
        {
            SetReward(+1f);
            EndEpisode();
        }

        if (other.TryGetComponent<FireBall>(out FireBall fireBall))
        {
            SetReward(-1f);
            EndEpisode();
        }

        if(other.TryGetComponent<Wall>(out Wall wall))
        {
            SetReward(-1f);
            EndEpisode();
        }
    }
    // void Update()
    // {
    //     xAxis = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
    //     zAxis = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

    //     transform.Translate(xAxis,0f,zAxis);
    // }

}
