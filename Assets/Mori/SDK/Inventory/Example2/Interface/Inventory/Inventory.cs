using System;
using System.Collections.Generic;
using System.Linq;

namespace Interface.Inventory
{
    public class Inventory
    {
        public Inventory(int capacity)
        {
            this.capacity = capacity;
        
            _slots = new List<IInventorySlot>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                _slots.Add(new InventorySlot());
            }
        }

        public event Action<object, IInventoryItem, int> OnInventoryItemAddedEvent;
        public event Action<object, Type, int> OnInventoryItemRemowedEvent;
        public event Action<object> OnInventoryStateChangedEvent;

        public int capacity { get; set; }
        public bool isFull => _slots.All(slot => slot.isFull);

        private List<IInventorySlot> _slots;

        public IInventoryItem[] GetAllItems()
        {
            var allItems = new List<IInventoryItem>();
            foreach (var slot in _slots)
            {
                if (!slot.isEmpty) allItems.Add(slot.item);
            }

            return allItems.ToArray();
        }

        public IInventoryItem[] GetAllItems(Type itemType)
        {
            var slotsOfType = _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType);

            return slotsOfType.Select(slot => slot.item).ToArray();
        }

        public IInventoryItem GetItem(Type itemType)
        {
            return _slots.Find(slot => slot.itemType == itemType).item;
        }

        public int GetItemsAmount(Type itemType)
        {
            var amount = 0;
            var allItemSlots = _slots.FindAll(slot => !slot.isEmpty && slot.item.state.isEquipped);
            foreach (var itemSlot in allItemSlots)
            {
                amount += itemSlot.amount;
            }

            return amount;
        }

        public bool HasItem(Type type, out IInventoryItem item)
        {
            item = GetItem(type);
            return item != null;
        }

        
        public void DisplacementFromSlotToSlot(object sender, IInventorySlot fromSlot, IInventorySlot toSlot)
        {
            if (fromSlot.isEmpty) return;
            if (!toSlot.isEmpty && fromSlot.itemType != toSlot.itemType) return;

            var slotCapacity = fromSlot.capacity;
            var fits = fromSlot.amount + toSlot.amount <= slotCapacity;
            var amountToAdd = fits ? fromSlot.amount : slotCapacity - toSlot.amount;
            var amountLeft = fromSlot.amount - amountToAdd;

            if (toSlot.isEmpty)
            {
                toSlot.SetItem(fromSlot.item);
                fromSlot.Clear();
                OnInventoryStateChangedEvent?.Invoke(sender);
            }

            toSlot.item.state.amount += amountToAdd;
            if (fits) fromSlot.Clear();
            else fromSlot.item.state.amount = amountLeft;
            OnInventoryStateChangedEvent?.Invoke(sender);
        }
        /*
        /// <summary>
        /// A function for removing a certain amount of items.
        /// This function is temporarily unavailable
        /// </summary>
        public void Remove(object sender, Type itemType, int amount = 1)
        {
            var slotWithItem = GetAllSlots(itemType);
            if (slotWithItem.Length == 0) return;

            var amountToRemove = amount;
            var count = slotWithItem.Length;

            for (int i = count - 1; i <= 0; i--)
            {
                var slot = slotWithItem[i];
                if (slot.amount >= amountToRemove)
                {
                    slot.item.state.amount -= amountToRemove;
                    if (slot.amount <= 0) slot.Clear();

                    OnInventoryItemRemowedEvent?.Invoke(sender, itemType, amountToRemove);
                    OnInventoryStateChangedEvent?.Invoke(sender);
                    break;
                }

                var amountRemoved = slot.amount;
                amountToRemove -= slot.amount;
                slot.Clear();
                OnInventoryItemRemowedEvent?.Invoke(sender, itemType, amountRemoved);
                OnInventoryStateChangedEvent?.Invoke(sender);
            }
        }*/

        private IInventorySlot[] GetAllSlots(Type itemType)
        {
            return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
        }

        public IInventorySlot[] GetAllSlots()
        {
            return _slots.ToArray();
        }

        public bool TryToAdd(object sender, IInventoryItem item)
        {
            var slotWithSameItemButNotEmpty = _slots.Find(slot => !slot.isEmpty && slot.itemType == item.type && !slot.isFull);
            if (slotWithSameItemButNotEmpty != null) return TryToAddToSlot(sender, slotWithSameItemButNotEmpty, item);

            var emptySlot = _slots.Find(slot => slot.isEmpty);
            if (emptySlot != null) return TryToAddToSlot(sender, emptySlot, item);

            return false;
        }

        public bool TryToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
        {
            var fits = slot.amount + item.state.amount <= item.info.maxItemsInInventorySlot;
            var amountToAdd = fits
                ? item.state.amount
                : item.info.maxItemsInInventorySlot - slot.amount;
            var amountLeft = item.state.amount - amountToAdd;
            var clonedItem = item.Clone();
            clonedItem.state.amount = amountToAdd;

            if (slot.isEmpty) slot.SetItem(clonedItem);
            else slot.item.state.amount += amountToAdd;

            OnInventoryItemAddedEvent?.Invoke(sender, item, amountLeft);
            OnInventoryStateChangedEvent?.Invoke(sender);

            if (amountLeft <= 0) return true;

            item.state.amount = amountLeft;

            return TryToAdd(sender, item);
        }
    }
}