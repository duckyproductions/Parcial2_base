using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : Hazard {

    bool alive = true;

    private void Update()
    {
        if (alive)
            transform.position += new Vector3(1, 0, 0) * Mathf.Sin(Time.time * 6) * 2 * Time.deltaTime;
        else
        {
            transform.eulerAngles += new Vector3(0, 0, 1) * 6 * 100 * Time.deltaTime;
            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime / 10;
        }
    }

    protected override void OnHazardDestroyed()
    {
        Destroy(gameObject , 5);
        alive = false;
        GetComponent<Rigidbody2D>().simulated = false;
    }
}
