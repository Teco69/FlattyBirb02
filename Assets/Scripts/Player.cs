using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player : MonoBehaviour
{
 
    public float velocidade = 0.0f ;
 
    public float entradaHorizontal ;
 
    public float entradaVertical ;

    public GameObject pfLaser ;
 
    public float tempoDeDisparo = 0.3f ;
 
    public float podeDisparar = 0.0f ;
 
 
    public bool possoDarDisparoTriplo = false ;
 
 
    public GameObject disparoTriplo ;
 
 
    public int vidas = 3;
 
    private GerenciadorDeUI _uiGerenciador;
 
 
    //private GerenciadorDoJogo _gerenciadorDoJogo;
 
 
    [SerializeField]
 
    private GameObject _explosaoPlayerPrefab;
 
 
    // Start is called before the first frame update
 
    void Start()
 
    {
 
        Debug.Log("Start de "+this.name);
 
        velocidade = 3.0f ;
 
        transform.position = new Vector3(0,0,0);
 
       // _gerenciadorDoJogo = GameObject.Find("GerenciadorDoJogo").GetComponent<GerenciadorDoJogo>();
 
 
        _uiGerenciador = GameObject.Find("Canvas").GetComponent<GerenciadorDeUI>();
 
        if (_uiGerenciador != null)
        {
            _uiGerenciador.AtualizarVidas(vidas);
 
        }
 
 
    }
 
 
    // Update is called once per frame
 
    void Update()
    {
 
       
 
        Movimento();
 
 
       
 
 
         if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
 
 
            if ( Time.time > podeDisparar ){
 
               
 
              if (possoDarDisparoTriplo == true ){
 
 
                  Instantiate(disparoTriplo,transform.position + new Vector3(0.1f, -0.2f, 0),Quaternion.identity);
 
 
               } else {  
 
 
                   Instantiate(pfLaser,transform.position + new Vector3(1.52f,-0.7f,0),Quaternion.identity);
 
              }
 
               
 
                 podeDisparar = Time.time + tempoDeDisparo ;
 
           
 
            }
 
 
 
        }
 
       
 
   }
 
 
 
   private void Movimento(){
 
 
       entradaHorizontal = Input.GetAxis("Horizontal");
 
        transform.Translate(Vector3.right*Time.deltaTime*velocidade*entradaHorizontal);
 
 
        if ( transform.position.x  > 8.85f) {
 
            transform.position = new Vector3(8.85f,transform.position.y,0);
 
        }
 
 
        if ( transform.position.x  < -8.85f  ) {
 
            transform.position = new Vector3(-8.85f,transform.position.y,0);
 
       
 
        }
 
 
        entradaVertical = Input.GetAxis("Vertical");
 
        transform.Translate(Vector3.up*Time.deltaTime*velocidade*entradaVertical);
 
 
        if ( transform.position.y  > 4.6f) {
 
            transform.position = new Vector3(transform.position.x, 4.6f, 0);
 
        }
 
 
        if ( transform.position.y  < -4.6f) {
 
            transform.position = new Vector3(transform.position.x, -4.6f, 0);
 
        }
 
 
 
 
 
   }
 
 
    public IEnumerator DisparoTriploRotina()
 
    {
 
        yield return new WaitForSeconds(7.0f);
 
        possoDarDisparoTriplo = false;
 
 
    }
 
 
 
    public void LigarPUDisparoTriplo()
 
    {
 
        possoDarDisparoTriplo = true;
 
        StartCoroutine(DisparoTriploRotina());
 
    }
 
 
 
    public void DanoAoPlayer()
 
    {
 
        // vidas = vidas - 1;
 
        vidas--;
 
 
        Debug.Log(vidas);
 
        _uiGerenciador.AtualizarVidas(vidas);
 
        if ( vidas == 0  )
        {
 
           // Instantiate(_explosaoPlayerPrefab,transform.position,Quaternion.identity);
 
            Destroy(this.gameObject);
 
        }
 
       
 
 
    }
 
 
}