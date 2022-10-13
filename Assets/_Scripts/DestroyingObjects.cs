using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingObjects : MonoBehaviour
{
    private void Update()
    {
        StartCoroutine(Destroying());
    }
    private IEnumerator Destroying()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
