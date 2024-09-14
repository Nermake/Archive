using UnityEngine;
using Random = UnityEngine.Random;

namespace Mori.SDK.Inventory
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] private ScreenView _screenView;

        private const string OWNER_1 = "Mori";
        private const string OWNER_2 = "Nagumo";

        private readonly string[] _itemIds = { "Axe", "Tea", "Coffee", "Ice" };
        
        private InventoryService _inventoryService;
        private ScreenController _screenController;
        private string _cacheOwnerId;

        private void Start()
        {
            var inventoryStateProvider = new InventoryStatePlayerPrefsProvider();
            _inventoryService = new InventoryService(inventoryStateProvider);

            inventoryStateProvider.LoadInventoryState();

            var inventoryState = inventoryStateProvider.InventoryState;

            foreach (var inventoryData in inventoryState.Inventories)
            {
                _inventoryService.RegisterInventory(inventoryData);
            }
            
            _screenController = new ScreenController(_inventoryService, _screenView);
            _screenController.OpenInventory(OWNER_1);
            _cacheOwnerId = OWNER_1;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _screenController.OpenInventory(OWNER_1);
                _cacheOwnerId = OWNER_1;
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _screenController.OpenInventory(OWNER_2);
                _cacheOwnerId = OWNER_2;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                var rIndex = Random.Range(0, _itemIds.Length);
                var rItemId = _itemIds[rIndex];
                var rAmount = Random.Range(1, 50);
                var result = _inventoryService.AddItemsToInventory(_cacheOwnerId, rItemId, rAmount);
                
                Debug.Log($"Item added: {rItemId}. Amount added: {result.ItemsAddedAmount}");
            }
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                var rIndex = Random.Range(0, _itemIds.Length);
                var rItemId = _itemIds[rIndex];
                var rAmount = Random.Range(1, 50);
                var result = _inventoryService.RemoveItems(_cacheOwnerId, rItemId, rAmount);
                
                Debug.Log($"Item removed: {rItemId}. Trying to remove: {result.ItemsToRemoveAmount}");
            }
        }
    }
}