using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2d;
    private bool mirandoIzquierda = true;
    [Header("Vida")]
    [SerealizeField] private float vida;
    [SerealizeField] private BarraDeVida barraDeVida;

    [Header("Ataque")]
    [SerealizeField] private Transform controladorAtaque;
    [SerealizeField] private float radioAtaque;
    [SerealizeField] private float dañoAtaque;


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2d;
    public Transform jugador;
    private bool mirandoIzquierda = true;
    [Header("Vida")]
    [SerealizeField] private float vida;
    [SerealizeField] private BarraDeVida barraDeVida;


    private void Star()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        barraDeVida.IncializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void update(){
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    public void TomarDaño(float daño)
    {
        vida -= daño;

        barraDeVida.CambiarVidaActual(vida);

        if (vida <=0)
        {
            animator.SetTrigger("Muerte");
        }
    }
    
    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if((jugador.position.x>transform.position.x && !mirandoIzquierda)) ||(jugador.position.x < transform.position.x && mirandoIzquierda))
        {
            mirandoIzquierda = !mirandoIzquierda;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180,0);
        }
    }
    
    public void Ataque ()
    {
        Collider2D[] objetos =Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach (Collider2D colision in objetos)
        {
            if(colision.CompareTag("Player")
            {
                colision.GetComponent<CombateJugador>().TomarDaño(dañoAtaque);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSherep(controladorAtaque.position, radioAtaque);
    }
}