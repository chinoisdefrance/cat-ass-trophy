using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBluePrint tourelle;
    public TurretBluePrint tourelleAutre;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Achete ma merde !!");
        buildManager.SelectTurretToBuild(tourelle);

    }

    public void PruchaseAnotherTurret()
    {
        Debug.Log("Achete mon autre merde");
        buildManager.SelectTurretToBuild(tourelleAutre);
    }
    public void PruchaseStandardTurret()
    {
        buildManager.SelectTurretToBuild(tourelle);
    }
}
