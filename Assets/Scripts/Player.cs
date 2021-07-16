using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{

    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField] 
    private GameObject _laserPrefab;
    [SerializeField]
    private Blaster _leftBlaster;
    [SerializeField]
    private Blaster _rightBlaster;
    [SerializeField]
    private Blaster _mainBlaster;



    // [SerializeField]
    // private float _fireRate = 0.5f;
    // private float _canFire = -1f;
    
    
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialPosition();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();
        
        if (_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space))
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
        _leftBlaster.Fire();
        _rightBlaster.Fire();
        _mainBlaster.Fire();
    }

    public void Damage()
    {
        _lives = _lives - 1;
        if (_lives <= 0)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
