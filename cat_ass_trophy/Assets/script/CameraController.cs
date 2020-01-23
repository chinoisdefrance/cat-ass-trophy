using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class CameraController : MonoBehaviour
{
    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;

    public float minY = 10f;
    public float maxY = 90f;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            doMovement = !doMovement;
        }
        if (!doMovement)
        {
            return;
        }


        if (Input.GetKey("z") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.height - panBorderThickness)
        {

            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("q") || Input.mousePosition.x <= panBorderThickness)
        {

            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log("ça bouge !!!");

        Vector3 pos = transform.position;
        Debug.Log(pos + " >> " + scroll);
        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
**/

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
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layers))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.distance <= limiteZoom) toClose = true;
            if (hit.distance >= limiteDezoom) toFar = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        }

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


        if ((Input.GetAxis("Mouse ScrollWheel") > 0 && !toClose) || (Input.GetAxis("Mouse ScrollWheel") < 0 && !toFar))
        {
            zoom = Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            transform.Translate(0, 0, zoom);
        }
    }
}