using UnityEngine;

public class DragTest : MonoBehaviour
{
    private Vector3 mouseOffset;
    private float mouseZ;

    private void OnMouseDown()
    {
        mouseZ = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetWorldMousePos();
    }

    private Vector3 GetWorldMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mouseZ;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        transform.position = GetWorldMousePos() + mouseOffset;
    }
}
