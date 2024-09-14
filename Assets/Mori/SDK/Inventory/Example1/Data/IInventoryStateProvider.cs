namespace Mori.SDK.Inventory
{
    public interface IInventoryStateProvider
    {
        void SaveInventoryState();
        void LoadInventoryState();
    }
}