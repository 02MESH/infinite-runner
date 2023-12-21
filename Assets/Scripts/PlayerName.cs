using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerName : MonoBehaviour
{

    public string nameOfPlayer;
    public string saveName;

    public Text inputText;
    public Text loadedName;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //key for name of player in player prefs 
        nameOfPlayer = PlayerPrefs.GetString("name", "none");
        //loads the name to the text of to whats typed in textbox 
        loadedName.text = nameOfPlayer;

    }

    public void SetName() {
        //takes name in textbox and sets the key name in player prefs to the name thats set in the textbox
        saveName = inputText.text;
        PlayerPrefs.SetString("name", saveName);
    }


}
