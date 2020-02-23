using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float destroyTime = 0.3f;
    public Vector3 Offset = new Vector3(0, 2, 0);

    //destroy gameObject after 3 seconds
    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += Offset;
    }
    void Update()
    {

        //transform.LookAt(Camera.main.transform);

    }
}
