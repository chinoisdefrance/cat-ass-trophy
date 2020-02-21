using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{

    public float speed = 10;
    public float boost = 10;
    float zoom;
    public float sensitivity = 10f;

    public LayerMask layers;
    public float limiteZoom = 10;
    public float limiteDezoom = 100;
    float acceleration;

    float deplacementHorizontal;
    float deplacementVertical;

    
    void Update()
    {
        bool toClose = false;
        bool toFar = false;
        RaycastHit hit;

        //distance between camera and ground
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layers))
        {
            
            if (hit.distance <= limiteZoom) toClose = true;
            if (hit.distance >= limiteDezoom) toFar = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

        //acceleration controler
        if (Input.GetKey(KeyCode.LeftShift))
        {
            acceleration = boost;
        }
        else
        {
            acceleration = 1;
        }

        deplacementHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime * acceleration;
        deplacementVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime * acceleration;

        transform.Translate(deplacementHorizontal, 0, 0);
        transform.Translate(0, deplacementVertical, 0);

        //zoom controler
        if ((Input.GetAxis("Mouse ScrollWheel") > 0 && !toClose) || (Input.GetAxis("Mouse ScrollWheel") < 0 && !toFar))
        {
            zoom = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            transform.Translate(0, 0, zoom);
        }
    }
}