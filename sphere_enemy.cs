using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class sphere_enemy : MonoBehaviour
{
    

    UnityEngine.AI.NavMeshAgent agent;

    GameObject player_object;

    Transform player_transform;

    GameObject effect_shoot;

    ParticleSystem shoot;

    float distance = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        player_object = GameObject.Find("Body");
        player_transform = player_object.GetComponent<Transform>();
    }

        // Update is called once per frame
        void Update()
    {
        distance = Vector3.Distance(player_transform.position, transform.position);
        if (distance <= 20f)
            {
                agent.SetDestination(player_transform.position);
            
            }
    }

    public void TakeDamage(float amount)
    {
        Die();
    }

    void Die()
    {
        Destroy(gameObject);

    }
}
