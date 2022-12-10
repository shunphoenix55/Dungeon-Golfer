using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // the height of this Transform is the height at which the ball goes out of bounds
    public Transform outOfBoundsPos;
    public Transform spawnPosition;

    private GameObject player;
    private Rigidbody rbPlayer;

    private void Start()
    {
        player = GameObject.FindWithTag(tag = "Player");
        rbPlayer = player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //BUG: the velocit
        if (player.transform.position.y <= outOfBoundsPos.position.y)
        {
            rbPlayer.velocity = Vector3.zero;
            rbPlayer.MovePosition(spawnPosition.position);
        }
    }
}
