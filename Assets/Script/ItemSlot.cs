using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    // Item Data
    public string itemName;
    public int itemQuantity;
    public Sprite itemIcon;
    public bool isFull;
      public ItemDetails ItemDetails => itemDetails;
    private ItemDetails itemDetails;


    // Item Slot
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    [SerializeField] private int MaxStackSize = 99;
    [SerializeField]  public GameObject SelectedPanel;

    public bool isItemSelected;
    public InventoryManager inventoryManager; 
    public void Awake()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }
    
   public void AddItem(ItemDetails item)
    {
        itemDetails = item;
        itemName = item.ItemName;
        // itemQuantity = item.Quantity;
        itemIcon = item.ItemIcon;
        isFull = true;
        AddQuantity(item.Quantity);

        // quantityText.text = itemQuantity.ToString();
        // quantityText.enabled = true;
        // itemImage.sprite = itemIcon;
    }
    public bool IsEmpty => itemQuantity <= 0;

    public bool CanStackWith(string otherItemName)
    {
        return !isFull && itemName == otherItemName;
    }

    public void AddQuantity(int quantity)
    {
        itemQuantity += quantity;
        isFull = itemQuantity >= MaxStackSize;
        quantityText.text = itemQuantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            RightClick();
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            LeftClick();
        }
        
    }

    public void RightClick()
    {
        Debug.Log("Right Clicked on");
    }
    public void LeftClick()
    {
        // inventoryManager.DeselectAllSlots();
        // isItemSelected = true;
        // SelectedPanel.SetActive(true);
        
        if (IsEmpty || inventoryManager == null)
        {
            return;
        }

        inventoryManager.SelectSlot(this);
        Debug.Log("Left Clicked on");
        
    }
}
