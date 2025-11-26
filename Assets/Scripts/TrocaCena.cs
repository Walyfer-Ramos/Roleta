using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class TrocaCena : MonoBehaviour
{
    public string Cena = "TelaDeCadastro";
    public void TrocarCena()
    {
        SceneManager.LoadScene(Cena);
    }
}
