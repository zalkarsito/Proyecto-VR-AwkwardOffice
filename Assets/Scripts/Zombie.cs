using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent Agent;
    public float speed = 1;


    void Update()
    {
        Vector3 targetPosition = Camera.main.transform.position;

        Agent.SetDestination(targetPosition);

        Agent.speed = speed;
    }
}
