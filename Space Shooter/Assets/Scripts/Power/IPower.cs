using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPower 
{
    void DisablePower();
    void ConsumePower(PlayerController controller);
}
