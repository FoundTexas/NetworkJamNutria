using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalamarEnemy : BasicEnemy
{
    public bool DispararArriba;
    private void Start()
    {
        AnimacionController = GetComponent<Animator>();
    }
    void Update()
    {

        ApuntarPlayer();
    }
    public override void DispararPlayer()
    {

        if (!MultiBull1)
        {
            GameObject bull = Instantiate(Bull1, transform.position, Quaternion.identity);
            AnimacionController.SetBool("CanShoot", true);
            Bullet Bullets = bull.GetComponent<Bullet>();
          
            if (DispararArriba)
            {
                Bullets.SetDirection(Vector2.up);
            }
            else
            {
                Bullets.SetDirection(Vector2.down);
            }
            
            Count1 = 0;
        }


    }
}
