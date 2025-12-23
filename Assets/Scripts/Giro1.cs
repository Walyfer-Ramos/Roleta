using UnityEngine;

public class Giro1 : MonoBehaviour
{
    public float velocidadeDoGiro = 100f;

    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - velocidadeDoGiro * Time.deltaTime);
    }
}
