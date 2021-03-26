using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public abstract class Trick : MonoBehaviour
{
    public TrickType trickType;
    public bool doTrick;
    public bool startedTrick;

    public Trick()
    {

    }

    public void DoTrick()
    {
        doTrick = true;
    }

    public void CheckDoTrick()
    {
        if(doTrick)
        {
            if(!startedTrick)
            {
                PreformTrick();
                startedTrick = true;
            }

            if(doTrick)
                UpdateTrick();
        }
    }

    public virtual void PreformTrick()
    {

    }
    public virtual void UpdateTrick()
    {

    }


}