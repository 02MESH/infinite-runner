using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CharacterSelect characterSelect;  // Reference to the CharacterSelect script
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        characterSelect = FindObjectOfType<CharacterSelect>();  // Find the CharacterSelect script in the scene
        if (characterSelect != null && characterSelect.characters.Length > 0)
        {
            // Set the offset based on the initially selected character
            offset = transform.position - characterSelect.characters[characterSelect.charIndex].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (characterSelect != null && characterSelect.characters.Length > 0)
        {
            // Update the camera position based on the selected character
            transform.position = characterSelect.characters[characterSelect.charIndex].transform.position + offset;
        }
    }
}
