using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class Ennemy : MonoBehaviour
{
    
    public float startHealth = 100;
    [SerializeField] private float health;

    public int value = 50;
    public int damage = 1;

    [Header("Deplacement")]
    public Transform destination;
    public float destinationDistance = 1;
    NavMeshAgent agent;

    [Header("Unity stuff")]
    public Image healthBar;

    [Header("Sound")]
    public AudioClip sndSpawn;
    public AudioClip sndDamage;
     public AudioClip sndDeath;
    AudioSource source;
    
    //ennemies sounds and the destination set
    void Start()
    {
        
        source = GetComponent<AudioSource>();
        source.clip = sndSpawn;
        source.Play();
        health = startHealth;


        destination = GameObject.FindWithTag("Destination").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destination.position);
        
    }

    //ennemies have to reach this point
    void Update()
    {
        if (agent.remainingDistance <= destinationDistance)
        {
            Endpath();
        }

    }

    //ennemy healthbar, they can take damages and die
    public void TakeDamage(float amount)
    {
        health -= amount;


        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            //source.clip = death;
            source.PlayOneShot(sndDeath);
            Die();
        }
        else
        {
            source.clip = sndDamage;
            source.Play();
        }
    }

    //if the ennmies die, Player earns money and they are destroyed
    void Die()
    {
        PlayerStats.Money += value;
        Destroy(gameObject);
    }

    //if ennemies reach the destination, they are destroyed and Player can lost more than one life (depends of ennemy type)
    void Endpath()
    {

        PlayerStats.DecreaseLive(damage);
        Destroy(gameObject);
    }
}
