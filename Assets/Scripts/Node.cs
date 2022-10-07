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
        if (!buildManager.CanBuild) return;

        if(turret != null)
        {
            Debug.Log("Cant build there!");
            return;
        }

        buildManager.BuildTurretOn(this);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;

        if (!buildManager.CanBuild) return;
        nodeRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = initialColor;
    }
}
