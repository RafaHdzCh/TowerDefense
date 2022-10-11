using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    private const float panSpeed = 30f;
    private const float scrollspeed = 5f;
    private const float panBorderThickness = 10f;

    //Movement limits
    private const float minY = 10f;
    private const float maxY = 80f;

    private const float minX = 0f;
    private const float maxX = 75f;

    private const float minZ = 0f;
    private const float maxZ = 60f;

    void Update()
    {
        if(GameManager.gameEnded == true)
        {
            this.enabled = false;
            return;
        }

        if( Input.GetKeyDown(KeyCode.C))
        {
            doMovement = !doMovement;
        }
        if (!doMovement) return;

        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y -= scroll * scrollspeed * Time.deltaTime * 500f;

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
