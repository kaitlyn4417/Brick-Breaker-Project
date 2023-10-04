using UnityEngine;

public class DragObjectBehavior : MonoBehaviour
{
    private Vector3 offset;
    private float mouseOffset = 10f;

    private void OnMouseDown()
    {
        offset = gameObject.transform.position - GetMouseWorldPosOnXAxis();
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = new Vector3(GetMouseWorldPosOnXAxis().x + offset.x, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }

    private Vector3 GetMouseWorldPosOnXAxis()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        plane.Raycast(ray, out distance);
        return ray.GetPoint(distance + mouseOffset);
    }
}

//code created with the help of chatGPT