using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Debug.DrawLine(mousePressDownPos, mouseReleasePos);
        Debug.Log( "Down:" + mousePressDownPos);
        Debug.Log("Up:" +mouseReleasePos);
        Shoot(mouseReleasePos - mousePressDownPos);
    }

    private float forceMultiplier = 3;
    void Shoot(Vector3 Force)
    {
        //if (isShoot)
        //    return;

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        isShoot = true;
    }

}