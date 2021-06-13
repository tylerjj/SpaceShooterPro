using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Section06 : MonoBehaviour
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
        // move down at 4 meters per second
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // if bottom of screen
        // respawn at top with a new random x position
        if (transform.position.y < _LOWERBOUNDY) {
            float randomX = Random.Range(_LOWERBOUNDX, _UPPERBOUNDX);
            transform.position = new Vector3(randomX, _UPPERBOUNDY, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit: " + other.transform.name);
        // if other is Player,
        //      damage the player
        //      destroy us.
        if (other.tag.Equals("Player"))
        {
            // damage player
            Player_Section06 player = other.transform.GetComponent<Player_Section06>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }        
        // if other is Laser,
        //      destroy laser,
        //      destroy us.
        else if (other.tag.Equals("Laser"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }



    }
}
