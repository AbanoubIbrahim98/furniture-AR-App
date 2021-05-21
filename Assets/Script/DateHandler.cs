using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class DateHandler : MonoBehaviour
{
    [SerializeField] private GameObject furniture;

    [SerializeField] private ButtonManger buttonPrefab;
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private List<item> _items;
    [SerializeField] private String label;

    private int id = 0;

    private static DateHandler instance;
    public static DateHandler Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<DateHandler>();
            }
            return instance;
        }
    }
    private async void Start()
    {
        _items = new List<item>();
        //Loaditems();
        await Get(label);
        CreateButtons();
    }

    // void Loaditems()
    // {
    //     var items_obj =Resources.LoadAll("items",typeof(item));
    //     foreach (var item in items_obj)
    //     {
    //         _items.Add(item as item);
    //     }
    //     
    // }
    void CreateButtons()
    {
        foreach (item i in _items)
        {
            ButtonManger b = Instantiate(buttonPrefab, buttonContainer.transform);
            b.ItemId = id;
            b.ButtonTexture = i.itemImage;
            id++;
        }
    }
        public void SetFurinute(int id)
    {
        furniture = _items[id].itemPrefab;
    }
    public GameObject GetFurniture()
    {
        return furniture;
    }

    public async Task Get(String label)
    {
        var locations = await Addressables.LoadResourceLocationsAsync(label).Task;
        foreach (var location in locations)
        {
            var obj = await Addressables.LoadAssetAsync<item>(location).Task;
            _items.Add(obj);
        }
    }
}
