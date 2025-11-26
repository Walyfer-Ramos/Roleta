using TMPro;
using UnityEngine;

public class MostrarResultado : MonoBehaviour
{
    public TextMeshProUGUI campoCopiado;


    void Start()
    {
        campoCopiado.text = ResultadoDaRoleta.textoCopiado;
    }
}
