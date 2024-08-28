using System.Collections.Generic;

public abstract class TowerState
{
    protected readonly Tower _tower;

    public abstract List<TowerActionData> GetActionData();
    public abstract void Upgrade();
    public abstract void Repair();
    public abstract void Salvage();

    
    public TowerState(Tower towerState)
    {
        _tower = towerState;
    }
    public virtual void Enter() {}
    public virtual void Exit() {}
    public virtual void Update() {}
}
