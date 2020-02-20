using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(AudioSource))]
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

    [Header("Sound")]
    public AudioClip spawn;
    public AudioClip damage;
    public AudioClip death;
    AudioSource source;
    void Start()
    {
        
        source = GetComponent<AudioSource>();
        source.clip = spawn;
        source.Play();
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
            //source.clip = death;
            source.PlayOneShot(death);
            Die();
        }
        else
        {
            source.clip = damage;
            source.Play();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    void Endpath()
    {
        
        PlayerStats.DecreaseLive();
        Destroy(gameObject);
    }
}
