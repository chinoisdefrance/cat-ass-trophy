using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]

public class WhooYarn : MonoBehaviour
{
    private Rigidbody rb;
    bool canDied = false;
    private Vector3 direction = new Vector3(0, 0, -1);
    public float force;
    public float delayBeforeDestroy  = 30;


    [Header("Sound")]
    public AudioClip spawn;
    public AudioClip destroySomething;
    AudioSource source;
    
    //when object is spawned, sound is played and force is applied, ennemy is destroyed at the end of 10 seconds
    void Start()
    {

        source = GetComponent<AudioSource>();
        source.clip = spawn;
        source.Play();


        rb = GetComponent<Rigidbody>();
        rb.AddForce(direction * force, ForceMode.Impulse);
        Invoke(nameof(modif), 10);
        Destroy(gameObject, delayBeforeDestroy);

    }

    //when a wool yarn from wool yarn attack touches a turret or/and an ennemy there are destroyed instantly 
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Turret") || collision.collider.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log(collision.collider.name);
            Destroy(collision.collider.gameObject);
            source.clip = destroySomething;
            source.Play();
        }
    }

    //object can be destroyed, if its position is above -10 or its velocity is equal to zero 
    void Update()
    {
        if (canDied)
        {
            if (transform.position.y < -10) Destroy(gameObject);

            if ((int)(rb.velocity.magnitude * 10) == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void modif()
    {
        canDied = true;
    }
}
