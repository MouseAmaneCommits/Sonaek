using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SampleTrick", menuName = "Tricks/Sample Trick")]
public class Trick : ScriptableObject
{
    // General Settings about Trick
    public string name = "Sample Trick";

    // Requirements for trick to be completed
    public float requiredYSpin = 0;
    public float requiredXSpin = 0;

    public bool done;
}
