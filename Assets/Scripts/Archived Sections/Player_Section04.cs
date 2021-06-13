using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Section04 : MonoBehaviour
{
    // LECTURE 022
    // CODING CONVENTION: variables that are private are given the prefix '_'
    //                    ( e.g. private float _speed = 3.5f;) 
    
    // LECTURE 022
    // The following is an attribute that allows us to serialize our
    // data and read/overwrite it in the inspector. This allows developers
    // to alter fields without other objects being able to access said fields.
    [SerializeField]
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // LECTURE 019
        // Take the current position = new position (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        * // LECTURE 020
        * // Move the Player's position 1 unit (1 meter irl) to the right per frame.
        * // Aside: The following is equivalent to: transform.Translate(new Vector3(1, 0, 0));
        * transform.Translate(Vector3.right);
        */

        /*
        * // LECTURE 021
        * // We want to move the player's position 1 unit to the right per second.
        * transform.Translate(Vector3.right * Time.deltaTime);
        */

        /* // LECTURE 021
        * // We want to move the player's position 5 units to the right per second. 
        * // Aside: The following is equivalent to: transform.Translate((new Vector3(5, 0, 0)) * Time.deltaTime);
        * transform.Translate(Vector3.right * 5 * Time.deltaTime);
        */

        /* // LECTURE 022
        * transform.Translate(Vector3.left * _speed * Time.deltaTime);
        */

        // LECTURE 023
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // LECTURE 023
        // When no horizontal input: new Vector3(1, 0, 0) * 0 * 3.5f * real time
        // When horizontal input to the right: new Vector3 (1, 0, 0) * (some value greater than 0 but less than or equal to 1) * 3.5f * real time
        // When horizontal input to the right: new Vector3(1, 0, 0) * (some value less than 0 but greater than or equal to -1) *3.5f * real time
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        
        // LECTURE 024
        // Optimized Version A:
        //      transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        // Optimized Version B: 
        //      Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        //      transform.Translate(direction * _speed * Time.deltaTime);

        // LECTURE 025
        // if player position on the y is greater than 0
        // y position = 0
        // else if position on the y is <= than -3.8f
        // y position = -3.8f

        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0 , 0);
        } else if (transform.position.y <= -3.8f) 
        {
            transform.position = new Vector3(transform.position.x, -3.8f, 0);
        }

        // if player on the x > 11
        // x pos = -11
        // else if player on the x is <= -11
        // x pos = 11

        if (transform.position.x >= 11.3f)
        {
            transform.position = new Vector3(-11.3f, transform.position.y, 0);
        } else if (transform.position.x <= -11.3f)
        {
            transform.position = new Vector3(11.3f, transform.position.y, 0);
        }
   }
}
