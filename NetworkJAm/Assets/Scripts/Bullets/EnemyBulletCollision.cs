using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
{
    public ParticleSystem bulletExplode;
    
    
    #region Hidra
    [SerializeField]private TipeEnemy TipoEnemigo;
   [SerializeField] private GameObject prefabBullHidra;
    [SerializeField] private List<Vector2> DireccionBull;
    [SerializeField]private int NumOfBullsHidra;
    #endregion
    #region Crap
    public float Count;

    #endregion
    public enum TipeEnemy
    {
        Glob,
        Hidra,
        Crab,
        Calamar
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collision");

        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().TakeDamage();
            Instantiate(bulletExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            switch (TipoEnemigo)
            {
                case TipeEnemy.Calamar:
                    if (collider.gameObject.CompareTag("Obstacle"))
                    {
                        Instantiate(bulletExplode, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }
                    ; break;
                case TipeEnemy.Hidra:
                    if (collider.gameObject.CompareTag("Obstacle"))
                    {

                        Bullet thisbull = GetComponent<Bullet>();
                        for (int i = 0; i < NumOfBullsHidra; i++)
                        {
                            GameObject bullHidra = Instantiate(prefabBullHidra, transform.position, Quaternion.identity);
                            Bullet Bull = bullHidra.GetComponent<Bullet>();
                            Bull.SetDirection(new Vector2(Random.Range(thisbull.Direction1.x * -1 + 0.5f, thisbull.Direction1.x * -1 + 1f), Random.Range(thisbull.Direction1.y * -1 + 0.5f, thisbull.Direction1.y * -1 + 1f)));
                            //Bull.SetDirection(new Vector2(thisbull.Direction1.x*-1, thisbull.Direction1.y*-1));
                        }
                        Instantiate(bulletExplode, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }

                    ; break;
                case TipeEnemy.Crab:
                    if (collider.gameObject.CompareTag("Obstacle"))
                    {
                        Instantiate(bulletExplode, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }; break;
                case TipeEnemy.Glob:
                    if (collider.gameObject.CompareTag("Obstacle"))
                    {
                        Instantiate(bulletExplode, transform.position, Quaternion.identity);
                        Destroy(gameObject);
                    }; break;
            }
        }

    }
  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Instantiate(bulletExplode, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }*/
}
