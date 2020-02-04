using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    //public float speed = 10f;
    //private Transform target;
    //private int wavepointIndex = 0;

    public float startHealth = 100;
    [SerializeField] private float health;

    public int value = 50;

    [Header("Deplacement")]
    public Transform destination;
    public float destinationDistance = 1;
    NavMeshAgent agent;

    [Header("Unity stuff")]
    public Image healthBar;
    void Start()
    {
        //target = waypoints.points[0];
        health = startHealth;


        destination = GameObject.FindWithTag("Destination").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
    }


    void Update()
    {
        if (agent.remainingDistance <= destinationDistance)
        {
            Endpath();
        }

    }

    public void TakeDamage(float amount)
    {
        health -= amount;


        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Endpath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
