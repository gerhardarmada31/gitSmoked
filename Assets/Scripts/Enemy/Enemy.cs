using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        IDamagable _playerDamage = other.GetComponent<IDamagable>();

        if (_playerDamage != null)
        {
            _playerDamage.TakeDamage(1);
        }
    }
}
