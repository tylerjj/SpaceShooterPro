using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Section05 : MonoBehaviour
{

    // TODO: speed variable of 8
    [SerializeField]
    private float _speed = 8.0f;
    //[SerializeField]
    //public float _offset = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y + _offset, 0);
    }

    // Update is called once per frame
    void Update()
    {

        //translate laser up
        transform.Translate(Vector3.up *_speed* Time.deltaTime);
        if (transform.position.y >= 8.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
