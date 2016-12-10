using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLibrary : MonoBehaviour {

    ArrayList script;
	// Use this for initialization
	void Awake () {
        script = new ArrayList();
        script.Add("A dark forest. You are surrounded by trees rustling on a gentle breeze. There's no one around you."); //0
        script.Add("* Where am I? *"); //1
        script.Add("After a few moments of staring into the darkness, you see a tiny spark of light in the distance, almost invisible behind the wall of trees."); //2
        script.Add("* I should go this way. * "); //3
        script.Add("Somewhere deep in the woods a fire is burning."); //4
        script.Add("* A campfire? Who may it be ? *"); //5
        script.Add("You headed out into the darkness. At first you thought your confused mind is playing tricks on you, but then you were sure. There was a campfire somewhere in there."); //6
        script.Add("You approach the fire. It’s slowly dying down, but you are sure that somebody was here not a long time ago."); //7
        script.Add("*Finally some warmth, I was freezing..."); //8
    }
	public string GetLine(int numberOfLine)
    {
        return (string)script[numberOfLine];
    }
	// Update is called once per frame
	void Update () {
		
	}
}
