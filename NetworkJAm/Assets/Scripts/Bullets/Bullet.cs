using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int type;
    public float LifeTime;
    Vector2 Direction;
    public float Speed;
    #region Cangrejo
    [SerializeField] private bool SeguirDisparo;
    public float MaxSteer;
 
    private Vector3 velocity = Vector3.zero;
    private Vector3 desired;
    public Transform objetivo;

    private Vector3 steer;
    #endregion


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
        Destroy(this.gameObject);
    }
    void Update()
    {
        
       
        if (SeguirDisparo)
        {
            seek(this.gameObject,PlayerMovement.instancia.transform);
        }
        else
        {
            transform.Translate(Direction * Speed * Time.deltaTime);
        }
    }
    public void seek(GameObject actual, Transform objetivo)
    {

        desired = Vector3.zero;
        desired = (objetivo.transform.position - actual.transform.position).normalized * Speed;

        steer = Vector3.ClampMagnitude(desired - velocity, MaxSteer);
        velocity += steer * Time.deltaTime;
        transform.position += velocity * Time.deltaTime;

        transform.up = velocity;

    }
    private void OnDisable()
    {
        CancelInvoke();
    }
 
}
