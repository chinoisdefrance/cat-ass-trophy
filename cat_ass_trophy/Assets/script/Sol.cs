using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Sol : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor = Color.red;
    public Vector3 positionOffSet;

    public GameObject turret;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        rend.enabled = false;

        buildManager = BuildManager.instance;

    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffSet;
    }

    
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        if (!buildManager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {            
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    //to build turrets while the mouse is on the ground which turrets can be build, if the player don't have enough money he/she can't build turrets anymore
    void OnMouseEnter()
    {

        rend.enabled = true;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.CanBuild)
        {
            return;
        }

        if (buildManager.HasMoney())
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

        
    }

    void OnMouseExit()
    {
        rend.enabled = false;

        rend.material.color = startColor;
    }
}
