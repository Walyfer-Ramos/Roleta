using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GirarRoleta : MonoBehaviour
{
    
    private float velocidade = 0f;
    private float desacerelando = 150f;
    private bool girar = false;

    public float offset = 0f;

    [SerializeField]private TextMeshProUGUI[] textosNaRoleta;

    void Update()
    {
        if (girar)
        {
                        //gira a roleta
            transform.Rotate(0, 0, -velocidade * Time.deltaTime);

            if(velocidade > 0)
            {
                velocidade -= desacerelando * Time.deltaTime;
            }
            else
            {
                velocidade = 0;
                girar = false;
                ParouDeGirar();
                
            }
        }
    }

    public void RoletaGirar()
    {
        velocidade = Random.Range(500f, 800f);
        girar = true;
    }

    public void ParouDeGirar()
    {
        //pegar o angulo
        float angulo = transform.eulerAngles.z;

        //ajusta conforme a seta
        float anguloAjustado = (angulo + offset + 360f) % 360f;

        //calcula o tamanho da fatia
        int total = textosNaRoleta.Length;
        float tamanhoFatia = 360f / total;

        //diz qual fatia está na seta
        int indice = Mathf.FloorToInt(anguloAjustado / tamanhoFatia);
        indice = (indice + total) % total;

        //pega o texto da fatia
        string textoFinal = textosNaRoleta[indice].text;

        // guarda o texto pra proxima cena
        ResultadoDaRoleta.textoCopiado = textoFinal;

        StartCoroutine(TrocarCenaDelay());

        Debug.Log(textoFinal);
        
    }
       
    private IEnumerator TrocarCenaDelay()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Sorteio");
    }

}
 