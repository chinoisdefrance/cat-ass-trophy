using UnityEngine;

public class Shop : MonoBehaviour
{
    //here is every turrets and special attack you can buy in the shop
    public TurretBluePrint tourelleFish;
    public TurretBluePrint tourelleWhool;
    public TurretBluePrint tourellePillow;
    public TurretBluePrint whoolYarn;
    
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
        tourelleFish.Init();
        tourelleWhool.Init();
        tourellePillow.Init();
        whoolYarn.Init();
        
    }

    //to select the standard turret
    public void SelectStandardTurret()
    {
       
        buildManager.SelectTurretToBuild(tourelleFish);

    }

    //to buy other turrets and special attack in the shop

    public void PurchaseFish()
    {
        buildManager.SelectTurretToBuild(tourelleFish);
    }
    public void PurchaseWhool()
    {
        buildManager.SelectTurretToBuild(tourelleWhool);
    }

    public void PurchasePillow()
    {
        buildManager.SelectTurretToBuild(tourellePillow);
    }
    public void PurchaseWhoolYarn()
    {
        buildManager.PlaceGodPower(whoolYarn);
    }
}
