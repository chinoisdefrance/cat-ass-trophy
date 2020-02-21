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

    //colorswap on the ground when Player puts turrets on it
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        rend.enabled = false;

        buildManager = BuildManager.instance;

    }

    //turrets takes position when they are on the ground
    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffSet;
    }

    //when the mouse is overhead on the ground which he can build turret, the color of the ground changes
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
    
    //to build turrets while the mouse is on the ground which turrets can be build, if the player don't have enough money he/she/it can't build turrets anymore and the groun color changes to red
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

    //hide ground
    void OnMouseExit()
    {
        rend.enabled = false;

        rend.material.color = startColor;
    }
}
