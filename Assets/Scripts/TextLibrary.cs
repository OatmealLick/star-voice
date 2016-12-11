﻿using System.Collections;
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
        script.Add("* Why... Why there is... so much... blood here. Is it... is it.... a knife in my hand? What is this, lying on the floor... A body?! *"); //19
        script.Add("A dark corridor, a body of an unknown man lies beneath your feet. You breathe heavily. You feel pain. A faint light shines on your hands, all covered in blood.");//20
        script.Add("*What the hell?!*");//21
        script.Add("-We have a critical situation, I repeat we have a critical situation. Everyone is to check in at the bridge, where proper procedures will be executed."); //22
        script.Add("You slowly walk into the corridor. It splits into two ways."); //23
        script.Add("You walk through an empty and silent corridor. The sound of your footsteps bounces around the walls making you question if you’re the only one here. ");//24
        script.Add("Following the signs you reach the bridge. Hundreds of lights cover the walls, but somehow it still seems too dark for you. When you enter the hall, you see a grand viewport on the opposite side.");//25
        script.Add("* Stars… are we… in space?*");//26
        script.Add("-Ekhem! ");//27
        script.Add("A man is standing in front of a big screen with thousands of symbols.");//28
        script.Add("-I don’t know if you are aware, but we are under an ongoing situation. A critical situation.");//29
        script.Add("Where are we?! Why I am here? What’s the situation?!");//30
        script.Add("A situation is critical and certain procedures must be executed. Thankfully, we’ve got a procedure for every situation in here. Every. Situation");//31
        script.Add("But what is it? Who am I? Can you answer me?");//32
        script.Add("Answers are not a part of currently executed procedure. It must be finished first.");//33
        script.Add("*Is he mad?*");//34
        script.Add("*Is there a reason to even talk to him?*");//35
        script.Add("*Is there?*");//36
        script.Add("*Of course there is a reason to talk with him. I need to know more!");//37
        script.Add("Please, tell me what’s happening!");//38
        script.Add("ANSWER ME!");//39
        script.Add("*He is a human being… Why would I kill him.*");//40
		script.Add("A broken sliding door blocks the entrance to the laboratories. You pry it open. Dents cover the walls of a brightly lit room. Pieces of sterile, white tiles and equipment are all over the floor."); //41
		script.Add("*What happened here?*");//42
		script.Add("You hear an inhuman screech coming from the distance. It’s getting closer. A fire extinguisher comes flying through a door. A man busts into the room with a crazed look in his eyes, forehead all covered in bloody scars.");//43
		script.Add("*What’s wrong with him !?*");//44
		script.Add("He lets out a horrifying scream and charges right at you. \nYou see an isolation cell on the left.");//45
		script.Add("");
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
