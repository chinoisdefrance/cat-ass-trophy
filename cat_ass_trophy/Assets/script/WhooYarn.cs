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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Turret") || collision.collider.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.collider.name);
            Destroy(collision.collider.gameObject);
            source.clip = destroySomething;
            source.Play();
        }
    }

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
