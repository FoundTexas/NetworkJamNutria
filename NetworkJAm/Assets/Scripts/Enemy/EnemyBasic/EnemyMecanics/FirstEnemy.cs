﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnemy : BasicEnemy
{
    

   
    void Update()
    {
 
        ApuntarPlayer();
    }
    public override void DispararPlayer()
    {
        if (MultiBull1)
        {
            for (int i = 0; i < NumOfBulls1; i++)
            {
                GameObject bull = Instantiate(Bull1, transform.position, Quaternion.identity);
                Bullet Bullets = bull.GetComponent<Bullet>();
                Bullets.SetDirection(DireccionBull1[i]);

                Count1 = 0;
            }
        }
        else
        {
            GameObject bull = Instantiate(Bull1, transform.position, Quaternion.identity);
            Bullet Bullets = bull.GetComponent<Bullet>();
            Vector2 DireccionPlayer = (PlayerPos.transform.position - transform.position).normalized;
            Bullets.SetDirection(DireccionPlayer);
            Count1 = 0;
        }
       
    
    }
}
