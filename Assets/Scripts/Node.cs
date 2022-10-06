using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    BuildManager buildManager;

    private GameObject turret;
    private Vector3 turretOffset = new Vector3(0f,0.5f,0f);

    [Header("Visual")]
    [SerializeField] Renderer nodeRenderer;
    private Color initialColor;
    public Color hoverColor;

    private void Start()
    {
        buildManager = BuildManager.instance;
        initialColor = nodeRenderer.material.color;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        if (buildManager.GetTurretToBuild() == null) return;

        if(turret != null)
        {
            Debug.Log("Cant build there!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
    }

    void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject()) return;

        if (buildManager.GetTurretToBuild() == null) return;
        nodeRenderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        nodeRenderer.material.color = initialColor;
    }
}
