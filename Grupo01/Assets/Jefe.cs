using System;
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
    [SerealizeField] private BarraDeVida BarraDeVida;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerealizeField] private float radioAtaque;
    [SerealizeField] private float dañoAtaque;

    private void Star()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        BarraDeVida.CambiarVidaActual(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }
    public void TomarDaño(float daño)
    {
        vida -= daño;

        BarraDeVida.CambiarVidaActual(vida);

        if (vida <= 0)
        {
            animator.SetTrigger("Death");
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        {
        if ((jugador.transform.position.x > transform.position.x && !mirandoIzquierda)||(jugador.transform.position.x < transform.position.x && mirandoIzquierda))
            mirandoIzquierda = !mirandoIzquierda;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);

        foreach(Collider2D colision in objetos)
        {
            if(colision.CompareTag("Player"))
            {
                colision.GetComponent<Jefe>().TomarDaño(dañoAtaque);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radius: radioAtaque);
    }
}
