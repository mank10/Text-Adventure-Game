using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        controller.currentText.text = "Type a verb followed by a noun eg \"go north\"";
        controller.currentText.text += "\nAllowed Verbs : \nGo, Use, Help, Examine, Give, Read, Get, TalkTo, Say, Help\n";
    }
}
