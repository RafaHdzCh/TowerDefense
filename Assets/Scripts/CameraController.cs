using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    private const float panSpeed = 30f;
    private const float scrollspeed = 5f;
    private const float panBorderThickness = 10f;
    private const float minY = 10f;
    private const float maxY = 80f;

    void Update()
    {
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
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
