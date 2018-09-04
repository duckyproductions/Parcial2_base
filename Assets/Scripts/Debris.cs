using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : Hazard {

    int rSpeed;
    bool on =  true;

    private void Update()
    {
        if(on)
        {
            while (rSpeed == 0)
            {
                rSpeed = Random.Range(-10, 10);
            }
            on = false;
        }

        transform.eulerAngles += new Vector3(0, 0, 1) * rSpeed * 100 * Time.deltaTime;
    }
}
