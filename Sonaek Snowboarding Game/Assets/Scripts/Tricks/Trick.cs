using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SampleTrick", menuName = "Tricks/Sample Trick")]

// Last Edited: Christian Sadykbayev
public class Trick : ScriptableObject
{
    // General Settings about Trick
    public string name = "Sample Trick";

    // Requirements for trick to be completed
    public float requiredYSpin = 0f;
    public float requiredXSpin = 0f;

    // The points that you get for completing the trick
    public float pointsReward;

    public bool done = false;
    public int counter = 0;
}
