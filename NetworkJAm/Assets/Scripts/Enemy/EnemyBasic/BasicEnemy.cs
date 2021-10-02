using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
 
    [SerializeField]private float RangoDeteccionEnemigo;
    [SerializeField]private LayerMask layerPlayer;
    private float Count;//Contador Disparar Cada

    [SerializeField] private GameObject Bull;
    [SerializeField] private List<Vector2> DireccionBull;
    [SerializeField] private bool MultiBull;
    private Animator animacionController;
    private bool RayTouchSometing;
    public float RangoDeteccionEnemigo1 { get => RangoDeteccionEnemigo; set => RangoDeteccionEnemigo = value; }
    public float Count1 { get => Count; set => Count = value; }
    public GameObject Bull1 { get => Bull; set => Bull = value; }
    public List<Vector2> DireccionBull1 { get => DireccionBull; set => DireccionBull = value; }
    public int NumOfBulls1 { get => NumOfBulls; set => NumOfBulls = value; }
    public bool MultiBull1 { get => MultiBull; set => MultiBull = value; }
    public Animator AnimacionController { get => animacionController; set => animacionController = value; }

    private int NumOfBulls;
    public void ApuntarPlayer()
    {
        float DistancePlayer = Vector2.Distance(transform.position, PlayerMovement.instancia.transform.position);
        Vector2 DireccionPlayer = (PlayerMovement.instancia.transform.position - transform.position).normalized;
        if (DistancePlayer < RangoDeteccionEnemigo)
        {


           // RaycastHit2D hit;
            RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, DireccionPlayer, DistancePlayer*100);
            if (hitinfo.collider != null)
            {
                if (hitinfo.collider.gameObject.layer==9)
                {
                    ContadorDispararCada();
                    if (Count >= 2.5f)
                    {
                        DispararPlayer();
                    }
                    Debug.DrawLine(transform.position, hitinfo.point, Color.red);
                    Debug.Log("Le estoy printeando al player");
                }
                else
                {
                    Debug.Log("Le estoy pegando a otra cosa");
                    Debug.DrawLine(transform.position, hitinfo.point, Color.green);
                }
            }
          //  Physics2D.Raycast(transform.position,DireccionPlayer, DistancePlayer, hit, layerPlayer);
           // print(hit.transform.position) ;
          /*  if (hit.collider.tag=="Player")
            {
                print("Hola");
                   /* ContadorDispararCada();
                    if (Count >= 2.5f)
                    {
                        DispararPlayer();
                    }
               
                
                  
                
           }
          */
               
            
                 
        }
    }
    public virtual void DispararPlayer()
    {
        //Diferente Tipos De Disparo Y Direcciones
     
    }
     public void AninFalse(string CanShoot)
    {
        AnimacionController.SetBool(CanShoot, false);
    }
    public void ContadorDispararCada()
    {
        Count += Time.deltaTime;
    }
    public void OnDrawGizmos()
    {
      
        Gizmos.DrawWireSphere(transform.position, RangoDeteccionEnemigo);
      
    }
   
}
