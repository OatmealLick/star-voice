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
        script.Add("Once you sat by the fire and calmed down your mind flooded with adrenaline, you began to realise what is going on."); //9
        script.Add("*I’m all alone in this dark forest. I can’t recall anything from my past. Everything is spinning. I feel dizzy.*"); //10
        script.Add("You are immersed in your thoughts.");//11
        script.Add("*How did I end up here? God, it’s so cold. I am so cold.");//12
        script.Add("You calmed down your mind and began to gather firewood.");//13
        script.Add("*It can wait. It all can wait. I will certainly freeze if I don't manage to keep up the fire.");//14
        script.Add("You began to gather firewood. Luckily it’s in no short supply. You threw it into the fire and soon a comforting crackle could be heard.");//15
        script.Add("*Far better... now I can think... *"); //16
        script.Add("Suddenly, you’ve heard a noise. Something is coming your way. Something big."); //17
        script.Add("* God, please, no… What is this? *"); //18
        script.Add("");
        script.Add("");

    }
    public string GetLine(int numberOfLine)
    {
        return (string)script[numberOfLine];
    }
	// Update is called once per frame
	void Update () {
		
	}
}
