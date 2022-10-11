using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;
    [SerializeField] GameObject buildEffect;
    [SerializeField] ParticleSystem buildEffectPartycleSystem;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    [SerializeField] NodeUI nodeUI;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("More than one BuildManager");
            return;
        }
        instance = this;
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.Money < turretToBuild.cost)
        {
            print("Not enough money.");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, buildEffectPartycleSystem.duration);
        Debug.Log("Turret build. Money left: " + PlayerStats.Money);

    }
}
