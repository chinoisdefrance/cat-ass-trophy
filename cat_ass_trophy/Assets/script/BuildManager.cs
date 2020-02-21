using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    // singleton
    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManger in scene!");
        }
        instance = this;
    }


    public GameObject standadTurretPrefab;
    public GameObject anotherTurretPrefab;


    [SerializeField] TurretBluePrint turretToBuild;

    public GameObject pelotte;
    private bool godPowerPlacement = false;
    public Transform[] spawnsWhoolYarn;


    public bool CanBuild { get { return turretToBuild != null; } }


    //Player can build turret if he has enough money
    public bool HasMoney()
    {
        if (PlayerStats.Money - turretToBuild.cost >= 0)
        {
            return true;
        }


        return false;
    }

    //if Player hasn't enough money to build turrets, he can't build them on the ground
    public void BuildTurretOn(Sol sol)
    {
        if (turretToBuild.isTurret == false) return;


        if (PlayerStats.Money < turretToBuild.cost) return;


        //when Player builds a turret, his money decreases
        PlayerStats.DecreaseMoney(turretToBuild.cost);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, sol.GetBuildPosition(), sol.transform.rotation);
        sol.turret = turret;
    }

    //wool yarns attack, wool yarns are instantiate
    internal void PlaceGodPower(TurretBluePrint obj)
    {

        godPowerPlacement = true;
        for (int i = 0; i < spawnsWhoolYarn.Length; i++)
        {

            Instantiate(obj.prefabs, spawnsWhoolYarn[i].position, Quaternion.identity);
        }
    }


    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        if (turret.isTurret == true)
        {
            godPowerPlacement = false;
            turretToBuild = turret;
        }
    }



}
