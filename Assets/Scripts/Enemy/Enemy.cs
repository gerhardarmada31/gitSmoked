using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IEnemy
{
    // public List<GameObject> WayPoints { get; set; }
    [SerializeField] public List<GameObject> wayPoints = new List<GameObject>();

    private void Awake()
    {
        // foreach (var _wayPoint in wayPoints)
        // {
        //     wayPoints.Add(_wayPoint);
        // }
    }

    public void AddEnemy(GameObject thisEnemy)
    {

        // if (!wayPoints.Contains(thisEnemy))
        // {
        //     wayPoints.Add(thisEnemy);
        //     Debug.Log("yo");
        // }
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
