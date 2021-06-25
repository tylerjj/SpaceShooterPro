using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Ammunition
{

    //[SerializeField]
    //private float _speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.up * Speed * Time.deltaTime);

        if (transform.position.y >= 8.5f)
        {
            Ammunition thisAmmo = this;
            AmmoPool.Instance.ReturnToPool(thisAmmo);
        }
    }
}
