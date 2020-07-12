using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connections[] connection;

    public List<Item> items = new List<Item>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public string GetItemsText()
    {
        if (items.Count == 0) return "";

        string result = "You see \n";
        bool first = true;

        foreach(Item item in items)
        {
            if(item.itemEnabled)
            {
                if (!first) result += " and ";
                result += item.description;
                first = false;
            }
        }
        result += "\n";
        return result;
    }

    public string GetConnectionsText()
    {
        string result = "";

        foreach (Connections connection in connection)
        {
            if(connection.connectionEnabled)
                result += connection.description + "\n";
        }
        return result;
    }

    internal bool HasItem(Item itemToCheck)
    {
        foreach (Item item in items)
        {
            if (item == itemToCheck && item.itemEnabled)
                return true;
        }
        return false;
    }

    public Connections GetConnection(GameController controller, string connectionNoun)
    {
        foreach (Connections connect in connection)
        {
            if (connect.connectionName.ToLower() == connectionNoun.ToLower())
                return connect;
        }
        return null;
    }
}
