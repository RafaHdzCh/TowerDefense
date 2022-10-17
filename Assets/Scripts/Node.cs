using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;
    [HideInInspector] public Vector3 turretOffset = new Vector3(0f,0.5f,0f);

    [Header("Visual")]
    [SerializeField] Renderer nodeRenderer;
    private Color initialColor;
    public Color hoverColor;
    public Color notEnoughMoneyColor;

    private void Start()
    {
        buildManager = BuildManager.instance;
        initialColor = nodeRenderer.material.color;
    }
    public Vector3 GetBuildPosition()
    {
        return transform.position + turretOffset;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild) return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        buildManager.buildSoundEffect.Play();
        turret = _turret;

        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, buildManager.buildEffectPartycleSystem.duration);
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            print("Not enough money to upgrade.");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        buildManager.buildSoundEffect.Play();
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, buildManager.buildEffectPartycleSystem.duration);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        buildManager.buildSoundEffect.Play();
        Destroy(turret);
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, buildManager.sellEffectPartycleSystem.duration);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;

        if(buildManager.HasMoney)
        {
            nodeRenderer.material.color = hoverColor;
        }
        else
        {
            nodeRenderer.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = initialColor;
    }
}
