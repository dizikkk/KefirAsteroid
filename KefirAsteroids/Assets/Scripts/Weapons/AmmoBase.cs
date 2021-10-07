using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBase : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("TimeToDie");
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 movement = new Vector3(0f, 1f, 0f);
        transform.Translate(movement * .5f * Time.fixedDeltaTime);
    }

    private IEnumerator TimeToDie()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
