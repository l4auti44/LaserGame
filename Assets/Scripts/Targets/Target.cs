using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : MonoBehaviour
{
   
    public abstract void DoAction();

    public abstract void Undo();
}
