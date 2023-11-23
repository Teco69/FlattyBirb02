using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    // Start is called before the first frame update

    private float _velocidade = 6.0f;

    [SerializeField]
    private GameObject _explosaoDoInimigo;


    private GerenciadorDeUI _uiGerenciador;

    void Start()
    {
        _uiGerenciador = GameObject.Find("Canvas").GetComponent<GerenciadorDeUI>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * _velocidade * Time.deltaTime);


        if ( transform.position.x < -10.0f)
        {
            transform.position = new Vector3(11.0f, Random.Range(3.3f, -0.86f), 0);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);

        if ( other.tag == "Tiro")
        {
            Destroy(other.gameObject);

            _uiGerenciador.AtualizarPlacar();

        }

        if ( other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.DanoAoPlayer();
            }

        }

        Destroy(this.gameObject);

        Instantiate(_explosaoDoInimigo, transform.position, Quaternion.identity);

    }
}