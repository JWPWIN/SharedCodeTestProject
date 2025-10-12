class Program
{
    private static  readonly string itemInfoLoadPath = "./gameTotalItemsInfo.txt";
    private static  readonly string itemInfoSavePath = "./gameTotalItemsInfo_TestSave.txt";

    static void Main(string[] args)
    {
        //测试物品数据库读取接口
        var itemList_item = JsonTool.LoadJson<ItemList_Item>(itemInfoLoadPath);
        //打印读取到的对象信息
        foreach (var item in itemList_item.gameTotalItemsInfo)
        {
            Console.WriteLine(item.name + ":" + item.tips);
        }
        //测试保存物品数据库接口
        JsonTool.SaveJson<ItemList_Item>(itemInfoSavePath, itemList_item);
        Console.WriteLine("Save json file: " + itemInfoSavePath);
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