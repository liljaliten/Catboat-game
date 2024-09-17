using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishData", menuName = "FishData", order = 1)]
public class FishData : ScriptableObject
{
    [Tooltip("Fish Name")]
    public string fishName; //<--- beh�ver koppla UI 
    [Tooltip("Catch Sprite")]
    public Sprite fishImage; //<--- beh�ver koppla UI 
    [Tooltip("The Higher Number the slower direction change aka randomness in movement")]
    public float fishMovement; //<--- beh�ver koppla till minigame
    [Tooltip("How fast it is idk")]
    public float fishSpeed; //<--- beh�ver koppla till minigame
    [Tooltip("0 - 100")]
    public int probability;
    [Tooltip("did this for tutorial")]
    public int fishDifficulty; //<--- test
}
