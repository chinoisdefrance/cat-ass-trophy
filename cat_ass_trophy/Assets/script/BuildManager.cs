using System;
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


    [SerializeField] TurretBluePrint turretToBuild;

    public GameObject pelotte;
    private bool godPowerPlacement = false;
    public Transform[] spawnsWhoolYarn;


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
    public void BuildTurretOn(Sol sol)
    {
        if (turretToBuild.isTurret == false) return;
        

            if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("TU ES PAUVRE");
            return;
        }

        PlayerStats.DecreaseMoney(turretToBuild.cost);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefabs, sol.GetBuildPosition(), sol.transform.rotation);
        sol.turret = turret;

        Debug.Log("Turret build ! Money left : " + PlayerStats.Money);
    }

    internal void PlaceGodPower(TurretBluePrint obj)
    {


        godPowerPlacement = true;
        for (int i = 0; i < spawnsWhoolYarn.Length; i++)
        {

           Instantiate(obj.prefabs, spawnsWhoolYarn[i].position,Quaternion.identity);
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


    //void Update()
    //{
    //    if (godPowerPlacement)
    //    {
    //        if (Input.GetMouseButtonDown(0))
    //        {

    //            var v3 = Input.mousePosition;
    //            v3.z = 10f;
    //            v3 = Camera.main.ScreenToWorldPoint(v3);
    //            Instantiate(turretToBuild.prefabs, v3, Quaternion.identity);
    //            //Transform cam = Camera.main.transform;
    //            //RaycastHit hit;
    //            //// Does the ray intersect any objects
    //            //if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
    //            //{
    //            //    Debug.DrawRay(cam.position, cam.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);



    //            //    Debug.Log(hit.point);
    //            //    if (HasMoney())
    //            //    {
    //            //        //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //            //        //Debug.DrawRay(transform.position, hit.point, Color.red);


    //            //        GameObject obj = Instantiate(turretToBuild.prefabs, cam.TransformDirection(Vector3.forward), Quaternion.identity);
    //            //        obj.transform.Translate(0, 5, 0);

    //            //        godPowerPlacement = false;
    //            //        PlayerStats.Money -= turretToBuild.cost;
    //            //    }
    //            //}
    //        }
    //    }

    //}
}
