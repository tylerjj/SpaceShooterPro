using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.0f;

    [SerializeField]
    public Vector3 InitialPosition { get; set; }
   
    public float Speed { get => _speed; set => _speed = value; }

    /*
    private void CalculateMovement()
    {
        throw new System.NotImplementedException();
    }
    */
   

    public void OnTriggerEnter2D(Collider2D other)
    {
        //TODO: Refactor this.
        if (!other.gameObject.CompareTag("Player"))
        {
            AmmoPool.Instance.ReturnToPool(this);
        }
        
    }
}
