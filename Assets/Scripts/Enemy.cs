using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4.0f;

    private const float _UPPERBOUNDY = 6.5f;
    private const float _LOWERBOUNDY = -6.5f;
    private const float _UPPERBOUNDX = 9.5f;
    private const float _LOWERBOUNDX = -9.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialPosition();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    void SetInitialPosition()
    {
        float randomX = Random.Range(_LOWERBOUNDX, _UPPERBOUNDX);
        transform.position = new Vector3(randomX, _UPPERBOUNDY, 0);
    }

    void CalculateMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < _LOWERBOUNDY) {
            float randomX = Random.Range(_LOWERBOUNDX, _UPPERBOUNDX);
            transform.position = new Vector3(randomX, _UPPERBOUNDY, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("On TriggerEnter");
        if (other.CompareTag("Player"))
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }        
        else if (other.CompareTag("Laser"))
        {
            // We are assuming that Laser is handling itself. 
            // Otherwise, try Ammunition ammo = other.transform.GetComponent<Ammunition>();
            // AmmoPool.ReturnToPool(ammo)
            Destroy(this.gameObject);
        }
    }
}
