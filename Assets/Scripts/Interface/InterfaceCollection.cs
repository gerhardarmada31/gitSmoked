using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface ICollectable
{
    void GetCoins(int coins);
}

public interface IEnemy
{

}

public interface IDamagable
{
    void TakeDamage(int damage);
}
