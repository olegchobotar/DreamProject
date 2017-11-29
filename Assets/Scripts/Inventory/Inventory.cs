using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public int slotsX, slotsY;
    public GUISkin skin;
    public List<Item_> inventory = new List<Item_>();
    public List<Item_> slots = new List<Item_>();
    private bool showInventory;
    private ItemDatabase database;

	private void Start () {
        for (int i = 0; i < (slotsX * slotsY); i++) {
            slots.Add(new Item_());
            inventory.Add(new Item_());
        }
        database = GameObject.FindWithTag("Item Database").GetComponent<ItemDatabase>();
        AddItem(1);
        AddItem(0);
        AddItem(1);

        print(InventoryContains(0));
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            showInventory = !showInventory;
        }
    }

    private void OnGUI() {
        GUI.skin = skin;

        if (showInventory) {
            DrawInventory();
        }
    }

    private void DrawInventory() {
        int i = 0;
        for (int y = 0; y < slotsY; y++)
            for (int x = 0; x < slotsX; x++) {
                Rect slotRect = new Rect(x * 50 + 200, y * 50 + 200, 48, 48);
                GUI.Box(slotRect , "" , skin.GetStyle("Slot"));
                slots[i] = inventory[i];
                if (slots[i].itemName != null) {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                }

                i++;
            }
    }

    void AddItem(int id) {
        for (int i = 0; i < inventory.Count; i++) {
            if (inventory[i].itemName == null) {
                for (int j = 0; j < database.items.Count; j++) {
                    if (database.items[j].itemID == id) {
                        inventory[i] = database.items[j];
                    }
                }
                break;
            }
        }
    }

    bool InventoryContains(int id) {
        bool result = false;
        for (int i = 0; i < inventory.Count; i++) {
            result = inventory[i].itemID == id;
            if (result) {
                break;
            }
        }
        return result;
    }
}
