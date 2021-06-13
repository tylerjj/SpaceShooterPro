using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Section06 : MonoBehaviour
{

    [SerializeField]
    private float _speed = 8.0f;

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void CalculateMovement()
    {
        //translate laser up
        transform.Translate(Vector3.up *_speed* Time.deltaTime);
        if (transform.position.y >= 8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
