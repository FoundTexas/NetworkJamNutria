using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;
    public float LifeTime;
    Vector2 Direction;
    public float Speed;
    [SerializeField] private bool SeguirDisparo; 
   
    public Vector2 Direction1 { get => Direction; set => Direction = value; }

    private void OnEnable()
    {
        Invoke("Destroy", LifeTime);
    }
    public void SetDirection(Vector2 dir)
    {
        Direction = dir;
    }
  
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    void Update()
    {
        transform.Translate(Direction * Speed * Time.deltaTime);
        if (SeguirDisparo)
        {
            Vector2 DireccionPlayer = (PlayerMovement.instancia.transform.position - transform.position).normalized;
            transform.Translate(DireccionPlayer * Speed * Time.deltaTime);
            
        
        }
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
 
}
