using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item_ {
    public string itemName;
    public int itemID;
    public string itemDescription;  //описание предмета
    public Texture2D itemIcon;
    public int itemPower;
    public int itemSpeed;
    public ItemType itemType;

    public enum ItemType {
        Weapon,
        Consumable,
        QuestItem
    }

    public Item_(string name, int id, string descr, int power, int speed, ItemType type) {
        itemName = name;
        itemID = id;
        itemDescription = descr;
        itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
        itemPower = power;
        itemSpeed = speed;
        itemType = type;
    }

    public Item_() {

    }
}
