namespace Interface.Inventory
{
    public interface IItemState
    {
        int amount { get; set; }
        bool isEquipped { get; set; }
    }
}