using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour
{
    public Transform canvas;
    public Image itemDisplay;
    private Hashtable inventory;
    private Image newItem;

    private character_1 player;
    private float x_pos;
    private float y_pos;
    private float x_pos_buffer;
    private float y_pos_buffer;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<character_1>();
        inventory = new Hashtable();

        x_pos = -475;
        y_pos = -5;

        x_pos_buffer = 55;
        y_pos_buffer = -60;
    }

    private void addItem(Image itemToDisplay, int item_id, int statToUpdate, float statToAdd, Sprite item_image)
    {
        
        // general gist of how an item will be added
            // try
                // add an item, if it doesnt exit
            // catch
                // if an item does exist already in our inventory
                // add a stack to that item
        try
        {
            Debug.Log("adding item...");
            inventory.Add(item_id, 1);
            
            itemDisplay.sprite = item_image;
            newItem = itemToDisplay;
            newItem.rectTransform.localPosition = new Vector3(x_pos, itemDisplay.rectTransform.localPosition.y, 0f);

            Instantiate(newItem, canvas);
            newItem.gameObject.SetActive(true);

            player.updateStat(statToUpdate, statToAdd);
            x_pos += x_pos_buffer;
        }
        catch
        {
            player.updateStat(statToUpdate, statToAdd);
            
            // update item counter on UI
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            // Debug.Log(other.GetComponent<item_id>().getItemId());
            item_id item_obj = other.GetComponent<item_id>();
            int id = item_obj.id;
            int statToAddChange = item_obj.statToChange;
            float statToAdd = item_obj.statToAdd;
            Sprite item_image = item_obj.item_image;
            
            addItem(itemDisplay, id, statToAddChange, statToAdd, item_image);
            Destroy(other.gameObject);
        }
    }
}
