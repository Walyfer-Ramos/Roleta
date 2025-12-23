using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoletaControlada : MonoBehaviour
{
    
    //private float velocidade = 0f;

    private bool girar = false;

    public float offset = 0f;

    [SerializeField]private TextMeshProUGUI[] textosNaRoleta;
    [SerializeField]private int premioForcado;
    [SerializeField]private float duracaoGiro = 4f;
    [SerializeField]private int voltasCompletas = 5;

    private float anguloInicial;
    private float anguloAlvo;
    private float giro;

    void Update()
    {
        if(!girar) return;
        giro += Time.deltaTime;
        float t = giro / duracaoGiro;
        t = Mathf.Clamp01(t); // garante que fica 0 ou 1;
        float tsuave = Mathf.SmoothStep(0f, 1f, t);


        float anguloAtual = Mathf.Lerp(anguloInicial, anguloAlvo, tsuave);

        transform.rotation = Quaternion.Euler(0f, 0f, anguloAtual);

        if(t >= 1f)
        {
            girar = false;
            ParouDeGirar();
        }
    }

    public void RoletaGirar()
    {
        int total = textosNaRoleta.Length;
        float tamanhoFatia = 360f / total;

        float anguloForcado = tamanhoFatia * premioForcado;
        anguloForcado -= tamanhoFatia / 2f; // meio da fatia;

        anguloInicial = transform.eulerAngles.z;

        anguloAlvo = anguloInicial - (360f * voltasCompletas) + anguloForcado;

        giro = 0f;
        girar = true;
    }

    public void ParouDeGirar()
    {
        //pegar o angulo
        float angulo = transform.eulerAngles.z;

        //ajusta conforme a seta
        float anguloAjustado = (angulo - 360f) % 360f;

        //calcula o tamanho da fatia
        int total = textosNaRoleta.Length;
        float tamanhoFatia = 360f / total;

        //diz qual fatia está na seta
        int indice = Mathf.FloorToInt(anguloAjustado / tamanhoFatia);
        indice = Mathf.Clamp(indice, premioForcado, total - 1);

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

    public void SetPremioForcado(int premio)
    {
        premioForcado = premio;
        Debug.Log("Premio Forcado:" + premio);
    }
}
