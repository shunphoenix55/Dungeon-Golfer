using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    // object to show the direction the ball is going 
    public GameObject directionIndicator;

    public float forceMultiplier = 300;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;
    //private Rigidbody rbIndicator;

    //private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rbIndicator = directionIndicator.GetComponent<Rigidbody>();
    }

    // Called when mouse is pressed over the collider
    private void OnMouseDown()
    {
        mousePressDownPos = rb.transform.position;
        directionIndicator.SetActive(true);
    }

    private void OnMouseDrag()
    {
        // raycasts from mouse pointer to scene
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(cameraRay, out RaycastHit hit);
        directionIndicator.transform.position = mousePressDownPos - (hit.point - mousePressDownPos);//so that the pointer is in the opposite direction
        
    }

    private void OnMouseUp()
    {
        mouseReleasePos = directionIndicator.transform.position;
        Shoot(-(mouseReleasePos - mousePressDownPos));//changing the direction again so that correct mouse position is calculated
        directionIndicator.SetActive(false);
    }

    void Shoot(Vector3 Force)
    {
        //if (isShoot)
        //    return;

        rb.AddForce(-Force * forceMultiplier);
        //isShoot = true;
    }

}