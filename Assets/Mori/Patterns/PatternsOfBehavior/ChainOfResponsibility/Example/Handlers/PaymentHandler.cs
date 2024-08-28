namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example
{
    public abstract class PaymentHandler
    {
        public PaymentHandler Successor { get; set; }
        protected string Message { get; set; }
        
        public abstract void HandleRequest(PaymentReceiver paymentReceiver, string message);
    }
}