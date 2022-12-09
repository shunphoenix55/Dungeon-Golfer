using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycastTest : MonoBehaviour
{
    
    public Camera mainCamera;
    public GameObject player;

    private Rigidbody rbPlayer;

    void Start()
    {
        rbPlayer = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 mousePosition;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(cameraRay, out RaycastHit hit);
        if (hit.rigidbody != rbPlayer)
        {
        mousePosition = hit.point;

        rbPlayer.transform.position = mousePosition;
        }

        else
        {
            rbPlayer.transform.position = new Vector3(0, 0, 0);
        }
    }
}
