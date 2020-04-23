using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
   void TakeDamage(int val);
   void GenerateBullet();
   void DisbaleEnemy();
}
