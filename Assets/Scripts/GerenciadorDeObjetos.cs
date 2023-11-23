using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorDeObjetos : MonoBehaviour
{

    [SerializeField]
    private GameObject _inimigoPrefab;

    [SerializeField]
    private GameObject[] _powerUps;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotinaGeracaoInimigo());
        StartCoroutine(RotinaGeracaoPowerUp());
    }

    IEnumerator RotinaGeracaoInimigo()
    {
        while (1 == 1)
        {
            Instantiate(_inimigoPrefab, new Vector3(11.0f, Random.Range(3.3f, -0.86f), 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
    }
        IEnumerator RotinaGeracaoPowerUp()
    {
        while (1 == 1)
        {
            int powerUpsAletatorio = Random.Range(0, 3);
            Instantiate(_powerUps[powerUpsAletatorio], new Vector3(11.0f, Random.Range(2.0f, -2.88f), 0), Quaternion.identity);
            yield return new WaitForSeconds(6);
        }
       
    }
}