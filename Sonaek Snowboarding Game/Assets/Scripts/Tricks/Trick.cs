using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SampleTrick", menuName = "Tricks/Sample Trick")]
public class Trick : ScriptableObject
{
    // Requirements for trick to be completed
    public float requiredYSpin = 0;
    public bool whileGrounded = false;
}
