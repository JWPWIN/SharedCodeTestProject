using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    private static  readonly string itemInfoLoadPath = "./gameTotalItemsInfo.txt";
    private static  readonly string itemInfoSavePath = "./gameTotalItemsInfoSave.txt";

    private static Dictionary<int, Item_Item> itemInfos = new Dictionary<int, Item_Item>();

    static void Main(string[] args)
    {
        var itemList_item = JsonTool.LoadJson<ItemList_Item>(itemInfoLoadPath);
        // foreach (var item in itemList_item.gameTotalItemsInfo)
        // {
        //     Console.WriteLine(item.name); 
        // }
        JsonTool.SaveJson<ItemList_Item>(itemInfoSavePath,itemList_item);
    }
}

[System.Serializable]
public class ItemList_Item
{
    public List<Item_Item> gameTotalItemsInfo;
}

[System.Serializable]
public class Item_Item
{
    public int id;
    public string name;
    public string icon;
    public int type;
    public int category;
    public int quality;
    public string quality_name;
    public int phy_attack;
    public int magic_attack;
    public int phy_defense;
    public int magic_defense;
    public int special_fun;
    public int special_fun_value;
    public string tips;
}