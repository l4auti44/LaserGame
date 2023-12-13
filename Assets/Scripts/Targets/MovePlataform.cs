using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlataform : Target
{
    [SerializeField] private GameObject plataform;

    override
    public void DoAction()
    {
        plataform.GetComponent<MoveAtoB>().enabled = true;
    }

    override
    public void Undo()
    {
        plataform.GetComponent<MoveAtoB>().enabled = false;
    }
}
