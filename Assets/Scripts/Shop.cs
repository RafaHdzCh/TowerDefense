using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    public void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandardTurret()
    {
        Debug.Log("StandardTurret Selected");
        buildManager.SetTurretToBuild(buildManager.standardTurretPrefab);
    }

    public void PurchaseMissileTurret()
    {
        Debug.Log("Missile Turret Selected");
        buildManager.SetTurretToBuild(buildManager.missileTurretPrefab);
    }

    public void PurchaseLaserTurret()
    {
        Debug.Log("Laser Turret Selected");
        buildManager.SetTurretToBuild(buildManager.laserTurretPrefab);
    }
}
