using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class inventoryController : MonoBehaviour
{
    public Transform canvas;
    public Image itemDisplay;
    private Hashtable inventory;

    private character_1 player;
    private float x_pos;
    private float y_pos;
    private float x_pos_buffer;
    private float y_pos_buffer;

    private List<Image> images;

    // Start is called before the first frame update
    void Start()
    {
        images = new List<Image>();
        
        player = GetComponent<character_1>();
        inventory = new Hashtable();

        x_pos = -475;
        y_pos = 535f;

        x_pos_buffer = 55;
        y_pos_buffer = -60;
    }

    private void addItem(item_id item_object)
    {
        
        // general gist of how an item will be added
            // try
                // add an item, if it doesnt exit
            // catch
                // if an item does exist already in our inventory
                // add a stack to that item
        try
        {
            //Debug.Log("adding item...");
            
            inventory.Add(item_object.id, 1);

            Image newImage = Instantiate(itemDisplay, canvas);
            images.Add(newImage);

            display tempDisplay = newImage.GetComponent<display>();

            //Debug.Log(x_pos);
            
            newImage.rectTransform.localPosition = new Vector3(x_pos, y_pos, 0f);
            newImage.sprite = item_object.item_image;
            tempDisplay.setDescription(item_object.item_name, item_object.description);
            tempDisplay.item_id = item_object.id;
            tempDisplay.gameObject.SetActive(true);

            x_pos += x_pos_buffer;
            //Debug.Log(x_pos + " should be changed");
            
            player.updateStat(item_object.statToChange, item_object.statToAdd);
        }
        catch
        {
            player.updateStat(item_object.statToChange, item_object.statToAdd);
            inventory[item_object.id] = (int) inventory[item_object.id] + 1;

            display tempDisplay;
            foreach (var v in images)
            {
                tempDisplay = v.GetComponent<display>();
                if (tempDisplay.item_id == item_object.id)
                {
                    tempDisplay.item_count.text = "x" + (int) inventory[item_object.id];
                    tempDisplay.item_count.gameObject.SetActive(true);
                    break;
                }
            }
            
            Debug.Log(inventory[item_object.id]);
            
            // update item counter on UI
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("item"))
        {
            // Debug.Log(other.GetComponent<item_id>().getItemId());
            item_id item_obj = other.GetComponent<item_id>();

            addItem(item_obj);
            Destroy(other.gameObject);
        }
    }
}
