using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool
{
    //Call for newly spawn object from the pool
    void OnObjectSpawn();
}
