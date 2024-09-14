using UnityEngine;

namespace Mori.SDK.Inventory.Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "Game/Inventory/ItemConfig", order = 0)]
    public class ItemConfig : ScriptableObject, IItem
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _icon;
        
        public string ID => _id;
        public Sprite Icon => _icon;
    }
}