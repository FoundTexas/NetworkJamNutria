using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour
{
    public ParticleSystem bulletExplode;
    public bool isEnemy;
    public int BulletDamage;
   
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collision");

        if (collider.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(bulletExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collider.gameObject.CompareTag("Enemy"))
        {
            collider.gameObject.GetComponent<BasicEnemy>().Dmg();
            Instantiate(bulletExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
