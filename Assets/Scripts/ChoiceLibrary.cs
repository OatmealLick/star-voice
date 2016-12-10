using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceLibrary : MonoBehaviour {

    ArrayList script;
    // Use this for initialization
    void Start() {
        script = new ArrayList();
        script.Add(ChoiceMaker(2, new string[] { "Look around carefully.", "Start walking." }));
        
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
