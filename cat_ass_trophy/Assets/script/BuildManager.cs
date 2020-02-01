using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

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

    
    private TurretBluePrint turretToBuild;

   public bool CanBuild { get { return turretToBuild != null; } }
    //public bool HasMoney { get { return turretToBuild != null; } }
    public bool HasMoney()
    {
        if (PlayerStats.Money - turretToBuild.cost >= 0)
        {
            return true;
        }


            return false;
    }
    public void BuildTurretOn (Sol sol)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("TU ES PAUVRE");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

       GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, sol.GetBuildPosition(), Quaternion.identity);
        sol.turret = turret;

        Debug.Log("Turret build ! Money left : " + PlayerStats.Money);
    }

    public void SelectTurretToBuild (TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
