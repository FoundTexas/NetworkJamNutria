using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdEnemy : BasicEnemy
{
    private GameObject bull;
    private Bullet Bullets;
   
   
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
             bull = Instantiate(Bull1, transform.position, Quaternion.identity);
          
            AnimacionController.SetBool("CanShoot", true);

             Bullets = bull.GetComponent<Bullet>();
            Count1 = 0;
        }
    }
 
 
 
    public void Destroy()
    {
   
        Destroy(gameObject);
    }
}
