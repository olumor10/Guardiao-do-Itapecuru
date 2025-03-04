using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour
{
    public float velocidade = 5f;  // Velocidade do movimento do chão
    public float escala = 1f;  // Escala do chão, ajuste conforme necessário
    private float LarguraImagem;  // Tamanho do chão para saber quando reposicionar
    private Vector3 posicaoInicial;

    void Start()
    {
        // Salva a posição inicial do chão
        posicaoInicial = transform.position;

        // Obter o componente SpriteRenderer
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            // Obter a largura do sprite em unidades do mundo e multiplicar pela escala
            LarguraImagem = spriteRenderer.sprite.bounds.size.x * escala;
        }
        else
        {
            Debug.LogError("SpriteRenderer não encontrado neste GameObject.");
        }
    }

    void Update()
    {
        // Move o chão para a esquerda
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        // Reposiciona o chão se ele sair da tela
        if (transform.position.x < posicaoInicial.x - LarguraImagem)
        {
            transform.position = posicaoInicial;
        }
    }
}