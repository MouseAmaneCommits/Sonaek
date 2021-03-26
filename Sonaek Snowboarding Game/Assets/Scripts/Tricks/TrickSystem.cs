using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TrickSystem : MonoBehaviour
{
    public Trick[] tricks;

    void Start()
    {

    }

    void Update()
    {
        foreach(Trick t in tricks)
        {
            t.CheckDoTrick();
        }
    }

    public Trick GetTrick(TrickType trickType)
    {
        Trick theTrick = null;
        foreach(Trick t in tricks)
        {
            if(t.trickType == trickType)
            {
                theTrick = t;
                break;
            }
        }

        return theTrick;
    }
}