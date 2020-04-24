using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseState
{
    protected GameObject gameObject;

    public BaseState(GameObject gameObject)
    {
        this.gameObject = gameObject;
    }

    public abstract void OnStateEnter();

    public abstract void OnStateExit();

    public abstract void OnStateDestroy();

    public abstract Type OnStateUpdate();

    public abstract Type OnStateFixedUpdate();

}
