using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRangedWeapon 
{

    public void Fire();

    /*
    public AmmoPool AmmunitionPool { get; }
    */

    public float AmmoLimit { get; set; }

    public float FireRate { get; set; }

    public float CanFire { get; }
}
