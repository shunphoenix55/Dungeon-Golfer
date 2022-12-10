using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    public GolfClub golfClub;

    // object to show the direction the ball is going 
    public GameObject directionIndicator;

    private float forceMultiplier;
    private float heightMultiplier;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;
    //private Rigidbody rbIndicator;

    //private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rbIndicator = directionIndicator.GetComponent<Rigidbody>();

        forceMultiplier = golfClub.forceMultiplier;
        heightMultiplier = golfClub.heightMultiplier;
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
        Vector3 difference = (hit.point - mousePressDownPos);
        // so that the difference in height doesn't matter
        // can be changed later or offset can be created if needed
        difference = new Vector3(difference.x, -difference.magnitude*heightMultiplier, difference.z); 
        directionIndicator.transform.position = mousePressDownPos - difference;//so that the pointer is in the opposite direction
        
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