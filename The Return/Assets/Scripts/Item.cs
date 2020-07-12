using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    [TextArea]
    public string description;

    public bool playerCanTake;

    public bool itemEnabled = true;

    public Item targetItem = null;

    public bool playerCanTalkTo = false;

    public bool playerCanGiveTo = false;

    public bool playerCanRead = false;

    public Interactions[] interactions;

    public bool InteractWith(GameController controller, string actionKeyword, string noun = "")
    {
        foreach(Interactions interaction in interactions)
        {
            if(interaction.action.keyword.ToLower() == actionKeyword.ToLower())
            {
                if (noun != "" && noun != interaction.textToMatch)
                    continue;

                foreach (Item itemDisable in interaction.itemsToDisable)
                    itemDisable.itemEnabled = false;

                foreach (Item itemEnable in interaction.itemsToEnable)
                    itemEnable.itemEnabled = true;

                foreach (Connections connectionDisable in interaction.connectionsToDisable)
                    connectionDisable.connectionEnabled = false;

                foreach (Connections connectionEnable in interaction.connectionsToEnable)
                    connectionEnable.connectionEnabled = true;

                if (interaction.teleportLocation != null)
                    controller.player.Teleport(controller, interaction.teleportLocation);

                controller.currentText.text = interaction.response;
                controller.DisplayLocation(true);
                return true;
            }
        }
        return false;
    }

}
