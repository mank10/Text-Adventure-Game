using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {
        if (ReadItems(controller, controller.player.currentLocation.items, noun))
            return;

        //It could be in the inventory
        if (ReadItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "There is no " + noun;
    }

    private bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (controller.player.CanReadItem(controller, item))
                {
                    if (item.InteractWith(controller, "read"))
                        return true;
                }
                controller.currentText.text = "There is nothing to read on the " + noun;
                return true;
            }
        }
        return false;
    }
}
