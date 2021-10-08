using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip h, b;
    public AudioSource audios;
    public static PlayerMovement instancia;//instanciaDelPlayer;
    [Header("Player Stuff:")]
    [SerializeField] private float speed = 0.5f, KnockBack = 6, bulletForce = 20f, Resistencia  = 1;
    [SerializeField] private Camera cam;
    [SerializeField] private Transform weaponHolder, firePoint;
    [SerializeField] private ParticleSystem shootParticle;
    [SerializeField] private GameObject bulletPrefab;

    public GameObject Dead;
    public float vel;

    public bool facingRight = false;
    Animator animator;
    Rigidbody2D rb2d;
    Vector2 movement,mousePos,lookDir;
    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    private void Update()
    {
        if (!Dead.activeInHierarchy)
        {
            if (Input.GetKeyDown("space"))
            {
                Time.timeScale = 0.3f;
            }
            else if (Input.GetKeyUp("space"))
            {
                Time.timeScale = 1;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                audios.PlayOneShot(b);
                rb2d.velocity = Vector2.zero;
                rb2d.AddRelativeForce(lookDir * -KnockBack); 
                //rb2d.AddForce(lookDir * -KnockBack);
                Instantiate(shootParticle, firePoint.position, firePoint.rotation);
                Bullet bullet = Instantiate(bulletPrefab, firePoint.position, this.transform.rotation).GetComponent<Bullet>();

                bullet.SetDirection(lookDir);
                //bulletRB.AddForce(firePoint.right * bulletForce + new Vector3(0f, Random.Range(-120f, 120f), 0f));
            }
            Animations();
        }
    }

    void FixedUpdate()
    {
        if (!Dead.activeInHierarchy)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            lookDir = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;

            if (lookDir.x < 0)
            {
                Flip(-1);
            }
            else if (lookDir.x > 0)
            {
                Flip(1);
            }


            if (movement != Vector2.zero)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(movement * speed);
            }

            if (rb2d.velocity.magnitude > 1)
            {
                rb2d.AddRelativeForce(rb2d.velocity.normalized *-Resistencia);
            }


                vel = rb2d.velocity.magnitude;
        }
    }

    public void Flip(int i)
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = i;
        transform.localScale = Scaler;
        Vector3 Scaler2 = transform.localScale;
        Scaler2.y = i;
        weaponHolder.localScale = Scaler2;
    }

    void Animations()
    {

        if (rb2d.velocity.x != 0)
        {
            if (lookDir.x > 0)
            {
                animator.SetFloat("X", rb2d.velocity.x);
            }
            else if(lookDir.x < 0)
            {
                animator.SetFloat("X", -rb2d.velocity.x);
            }
        }

        animator.SetFloat("Y", rb2d.velocity.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    public void Dmg()
    {
        Dead.SetActive(true);
        FindObjectOfType<SceneLoader>().Reload();
    }

}
