using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Blaster : MonoBehaviour
{

    [SerializeField] private float _ammoLimit;  
    [SerializeField] private float _fireRate;
    [SerializeField] private float _canFire;

    public float AmmoLimit { get  => _ammoLimit; set => _ammoLimit = value; }
    public float FireRate { get => _fireRate; set => _fireRate = value; }
    public float CanFire { get => _canFire; private set => _canFire = value; }

    public void Fire()
    {
        if (Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            var shot = LaserPool.Instance.Get();
            shot.transform.rotation = transform.rotation;
            shot.transform.position = transform.position;
            shot.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}
