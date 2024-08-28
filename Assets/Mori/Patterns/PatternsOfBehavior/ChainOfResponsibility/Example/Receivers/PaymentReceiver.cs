namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example
{
    public class PaymentReceiver
    {
        public string Name { get; set; }
        public bool BankTransfer { get;  set; }
        public bool PayPalTransfer { get;  set; }
        public bool MoneyTransfer { get;  set; }
    }
}