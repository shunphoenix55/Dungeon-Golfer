using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    public GameObject directionIndicator;

    public float forceMultiplier = 300;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;
    private Rigidbody rbIndicator;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rbIndicator = directionIndicator.GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = rb.transform.position;
        directionIndicator.SetActive(true);
    }

    private void OnMouseDrag()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(cameraRay, out RaycastHit hit);
        directionIndicator.transform.position = hit.point;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = directionIndicator.transform.position;
        Shoot(mouseReleasePos - mousePressDownPos);
        directionIndicator.SetActive(false);
    }

    void Shoot(Vector3 Force)
    {
        //if (isShoot)
        //    return;

        rb.AddForce(Force * forceMultiplier);
        isShoot = true;
    }

}