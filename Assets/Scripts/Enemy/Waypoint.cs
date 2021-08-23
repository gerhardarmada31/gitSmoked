using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private float waypointSize = 0.5f;
    private Enemy parentEnemy;

    private void Awake()
    {
        // parentEnemy = GetComponentInParent<Enemy>();

        // if (parentEnemy != null)
        // {
        //     parentEnemy.AddEnemy(this.gameObject);
        // }


    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, waypointSize);
    }
}
