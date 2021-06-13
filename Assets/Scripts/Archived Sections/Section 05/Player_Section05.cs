using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Section05: MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField] 
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        // if i hit the space key
        // spawn gameObject.
        
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            // Example of logic for our firing cooldown
            //firing rate = fr = .5;
            //can fire = cf = -1f;
            //Time.time = time = 30;

            //time > cf, so
            //    cf = time + fr = 30.5;
            //30.1 < cf,
            //30.2 < cf,
            //30.3 < cf, 
            //30.4 < cf, 
            //30.5 >= cf, so
            //    cf = 30.5 + .5 = 31;
            //30.6 < cf,
            //30.7 < cf, ...
            _canFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
        }
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);

        // The Clamp function seems to bound our horizontal axis movement. 
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        }
        else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }

        
    }

    void SetInitialPosition()
    {
        transform.position = new Vector3(0, 0, 0);
    }
}
