using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int AmountCoin;


    void OnTriggerEnter(Collider other)
    {
        ICollectable _coinCollect = other.GetComponent<ICollectable>();
        if (_coinCollect != null)
        {
            _coinCollect.GetCoins(AmountCoin);
            Object.Destroy(this.gameObject);
        }
    }
}
