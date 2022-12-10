using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A Scriptable Object for Golf Clubs
[CreateAssetMenu(menuName ="Scriptable Objects/Golf Club", fileName ="Golf Club")]
public class GolfClub : ScriptableObject
{
    // Multiplier of force of the shot
    public float forceMultiplier = 100f;
    public float heightMultiplier = 1f;
}
