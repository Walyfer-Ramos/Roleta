using UnityEngine;

public class Giro2 : MonoBehaviour
{
    public float velocidadeDoGiro2 = 100f;

    void Update()
    {
        transform.Rotate(0f, 0f, -velocidadeDoGiro2 * Time.deltaTime);
    }
}
