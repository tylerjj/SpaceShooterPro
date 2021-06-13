using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Section06: MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField] 
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
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

    void FireLaser()
    {
        _canFire = Time.time + _fireRate;
        Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.75f, 0), Quaternion.identity);
    }

    public void Damage()
    {
        _lives--;

        // check if dead
        // destroy us

        if (_lives <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
