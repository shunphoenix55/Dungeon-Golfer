using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;
    [SerializeField]
    private LayerMask layerMask;
    public GolfClub golfClub;
    [SerializeField] private float maxDragDistance = 4;
    [SerializeField] private float stationaryDeadzone = 0.1f; // the maximum magnitude of velocity at which the ball is considered stationary

    // object to show the direction the ball is going 
    public GameObject directionIndicator;
    // indicator to show that the ball is stationary and ready to be shot
    public GameObject stationaryIndicator;

    private float forceMultiplier;
    private float heightMultiplier;

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;
    //private Rigidbody rbIndicator;

    private bool isStationary;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rbIndicator = directionIndicator.GetComponent<Rigidbody>();

        forceMultiplier = golfClub.forceMultiplier;
        heightMultiplier = golfClub.heightMultiplier;

        isStationary = true;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude <= stationaryDeadzone)
        {
            isStationary = true;
            stationaryIndicator.SetActive(true);
        }
        //stationaryIndicator.transform.position = transform.position;
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

        Physics.Raycast(cameraRay, out RaycastHit hit, Mathf.Infinity, layerMask);
        Vector3 difference = (hit.point - mousePressDownPos);

        // so that the user can't drag infinitely
        if (difference.magnitude > maxDragDistance)
        {
            difference = difference.normalized * maxDragDistance;
        }

       // height of shot depends on value specified in the Golf Club chosen
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
        // only allow the user to shoot if the ball is stationary
        if (!isStationary)
            return;

        rb.AddForce(-Force * forceMultiplier);
        isStationary = false;
        stationaryIndicator.SetActive(false);
    }

}