using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLibrary : MonoBehaviour {

    ArrayList script;
    // Use this for initialization
    void Start() {
        script = new ArrayList();
        script.Add(ChoiceMaker(2, new string[] { "Look around carefully.", "Start walking." }));
        script.Add(ChoiceMaker(2, new string[] { "Sit and think.", "Start gathering wood to keep up the fire." }));
        script.Add(ChoiceMaker(1, new string[] { "Take a branch from the campfire." }));
        script.Add(ChoiceMaker(2, new string[] { "Hit it.", "Wave the torch." }));
        script.Add(ChoiceMaker(2, new string[] { "To the bridge.", "To the labs." }));
		script.Add(ChoiceMaker(2, new string[] { "Run away from him.", "Face him." }));

    }
    public string[] ChoiceMaker(int size, string[] choices){
        string[] toReturn = new string[size];
        for (int i=0; i<choices.Length; i++){
            toReturn[i] = choices[i];
        }
        return toReturn;
    }
    public string[] GetChoice(int numberOfChoice)
    {
        return (string[])script[numberOfChoice];
    }
    // Update is called once per frame
    void Update () {
		
	}
}
