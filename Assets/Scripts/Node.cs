using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    [System.NonSerialized] public GameObject turret;
    [System.NonSerialized] public Vector3 turretOffset = new Vector3(0f,0.5f,0f);

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

        buildManager.BuildTurretOn(this);
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
