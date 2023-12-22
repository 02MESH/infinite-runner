using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lighting Preset", menuName = "Scriptables/Lighting Preset", order = 1)]

public class LightingPreset : ScriptableObject
{
    // all represent gradients for custom day night cycle
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}
