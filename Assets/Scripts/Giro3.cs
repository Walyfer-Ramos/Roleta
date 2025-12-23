using UnityEngine;

public class Giro3 : MonoBehaviour
{
    public float velocidadeDoGiro3 = 100f;

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, -velocidadeDoGiro3 * Time.deltaTime);
    }
}
