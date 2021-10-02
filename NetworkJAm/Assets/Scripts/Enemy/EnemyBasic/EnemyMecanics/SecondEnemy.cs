using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemy : BasicEnemy
{
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
    
       if(!MultiBull1)
        {
            GameObject bull = Instantiate(Bull1, transform.position, Quaternion.identity);
            AnimacionController.SetBool("CanShoot", true);
            Bullet Bullets = bull.GetComponent<Bullet>();
            Vector2 DireccionPlayer = (PlayerMovement.instancia.transform.position - transform.position).normalized;
            Bullets.SetDirection(DireccionPlayer);
            Count1 = 0;
        }


    }
}
