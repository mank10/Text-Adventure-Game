using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text historyText;
    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;

    // Start is called before the first frame update
    void Start()
    {
        historyText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description + "\n";
        description += player.currentLocation.GetConnectionsText();
        description += player.currentLocation.GetItemsText();
        if (additive)
            currentText.text += "\n" + description;
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        HistoryLogText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void HistoryLogText()
    {
        historyText.text += "\n\n";
        historyText.text += currentText.text;

        historyText.text += "\n\n";
        //The color tag thingy is not working here.
        historyText.text += textEntryField.text;
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };

        string[] separatedWords = input.Split(delimiter);

        foreach(Action action in actions)
        {
            if (action.keyword == separatedWords[0])
            {
                if (separatedWords.Length > 1)
                {
                    action.RespondToInput(this, separatedWords[1]);
                }
                else
                {
                    action.RespondToInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing Happens! (Having Trouble? Type Help.)";
    }

}
