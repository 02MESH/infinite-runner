using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectible : MonoBehaviour
{
    //applies transform effect and changes player position
    public abstract void ApplyEffect(Transform playerTransform);
}
