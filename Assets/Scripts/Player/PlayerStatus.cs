using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDamagable
{
    [SerializeField] private int health = 5;
    public Player_SO player;


    //CONST
    public int myCoin { get; set; }
    // private bool isInvunerable = false;

    private void Awake()
    {

    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(IFrameTime());
    }

    IEnumerator IFrameTime()
    {
        yield return new WaitForSeconds(1f);

    }
}
