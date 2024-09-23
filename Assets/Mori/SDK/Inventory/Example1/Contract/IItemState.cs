namespace Mori.SDK.Inventory
{
    public interface IItemState
    {
        int Amount { get; set; }
        bool IsEquipped { get; set; }
    }
}