﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    
    public GameObject ItemPrefab;
    public GameObject DescriptionTemplate;
    private GameObject DescriptionTemplate1;
    private int itemID;
    private int itemTypeID;
    private int price;
    public GameObject[] clickerManager;
    public GameObject youDontHaveEnoughAlert;
    public GameObject youAlreadyHaveItAlert;
    private string itemDescription;

    private void Start()
    {
        clickerManager = GameObject.FindGameObjectsWithTag("GameController");
       // Debug.Log(itemDescription);
    }

  
    public void action()
    {
        if (priceCheck(clickerManager[0].GetComponent<GameControlScript>().strokesAmount))
        {

            if (itemTypeID == 1)
            {
                addItemToInventory();
            }
            else if (itemTypeID == 2)
            {
                addItemToEquipment();
            }
            else if (itemTypeID == 3)
            {
                addItemToWeapon();
            }
            else
            {
                addItemToClicker();
                exPrice();
            }

        } else
        {
            initAlert(youDontHaveEnoughAlert);
        }
    }

    private void initAlert(GameObject alertPrefab)
    {
        GameObject alert = Instantiate(alertPrefab, gameObject.transform, false);
        Destroy(alert, 1);
    }
    
    private bool priceCheck(int myPoint)
    {
        if(myPoint < price)
        {
            return false;
        }

        return true;
    }

    public void addItemToInventory()
    {
        PlayerInventory inventory;
        inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerInventory>();
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                inventory.isFull[i] = true;
                inventory.itemsAtSlots[i] = Instantiate(ItemPrefab, inventory.slots[i].transform, false);
                break;
            }

        }
        clickerManager[0].GetComponent<GameControlScript>().strokesAmount -= price;
    }

    public void addItemToEquipment()
    {
        PlayerEquipment equipment;
        equipment = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerEquipment>();
        if (equipment.Equiped != null)
        {
            if (equipment.Equiped.GetComponent<shieldEquipment>().fullShield())
                initAlert(youAlreadyHaveItAlert);
            else
            Destroy(equipment.Equiped);
        }
        equipment.Equiped = Instantiate(ItemPrefab, equipment.EquipmentSlot.transform, false);
        Debug.Log("newPrefav");
        clickerManager[0].GetComponent<GameControlScript>().strokesAmount -= price;
    }

    public void addItemToWeapon()
    {
        PlayerEquipment weapon;
        weapon = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerEquipment>();
        if (weapon.addtoGunCollection(ItemPrefab))
            clickerManager[0].GetComponent<GameControlScript>().strokesAmount -= price;
        else
            initAlert(youAlreadyHaveItAlert);

    }

    public void addItemToClicker()
    {
        GameControlScript clickerManager;
        clickerManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameControlScript>();
        Instantiate(ItemPrefab, clickerManager.Clicker.transform, false);
        // equipment.Equiped = Instantiate(ItemPrefab, equipment.EquipmentSlot.transform, false);
        Debug.Log("newPrefav");
        clickerManager.strokesAmount -= price;
    }

    public void setImagePrefab(GameObject imagePrefab)
    {
        ItemPrefab = imagePrefab;
    }

    public void setItemID(int itemID)
    {
        this.itemID = itemID;
    }

    public void setItemTypeID(int itemTypeID)
    {
        this.itemTypeID = itemTypeID;
    }

    public void setPrice(int price)
    {
        this.price = price;
    }

    public void exPrice()
    {
        float a = price * 1.25f;
        price = (int) a;
        transform.GetChild(1).GetComponent<Text>().text = price + "";
    }

    public void setDescription(string des)
    {
        this.itemDescription = des;
    }
    
    public void displayDes()
    {
        Debug.Log(itemDescription);
        DescriptionTemplate1 = Instantiate(DescriptionTemplate, gameObject.transform.parent.parent.parent.parent);
        DescriptionTemplate1.transform.GetChild(0).GetComponent<Text>().text = itemDescription;
        Invoke("destroyDes", 2);
    }

    public void destroyDes()
    {
        Destroy(DescriptionTemplate1);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {

        displayDes();
    }

    //Detect when Cursor leaves the GameObject
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        destroyDes();
    }

}

