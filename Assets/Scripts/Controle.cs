using UnityEngine;
using TMPro;

public class Controle : MonoBehaviour
{
    public TMP_InputField inputPremio;
    public RoletaControlada roleto;

    public void AlterarPremio()
    {
        int valor;

        if (int.TryParse(inputPremio.text, out valor))
        {
            //roleto.premioForcado = valor;
            Debug.Log("Premio alterado para: " + valor);
        }
        else
        {
            Debug.LogWarning("Valor inválido!");
        }
    }
}
