using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
    public List<Item_> items = new List<Item_>();

    private void Start() {
        items.Add(new Item_("Magic Hat", 0, "You will be mag!", 2, 0, Item_.ItemType.Weapon));
        items.Add(new Item_("Silver Sword", 1, "You will be a warrior!", 5, 0, Item_.ItemType.Weapon));
    }
}
