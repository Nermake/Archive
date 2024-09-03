namespace Mori.Patterns.PatternsOfBehavior.Visitor
{
    public interface IAccount
    {
        void Accept(IVisitor visitor);
    }
}