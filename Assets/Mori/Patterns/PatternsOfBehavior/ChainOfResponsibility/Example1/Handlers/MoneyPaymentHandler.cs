using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example1
{
    public class MoneyPaymentHandler : PaymentHandler
    {
        public override void HandleRequest(PaymentReceiver paymentReceiver, string message)
        {
            Message += message;
            Message += "Выполняем перевод через системы денежных переводов... \n";
                
            if (paymentReceiver.MoneyTransfer)
            {
                Message += "    Перевод выполнен успешно! \n";
                Debug.Log(Message);
            }
            else
            {
                Message += "    Не удалось выполнить перевод через системы денежных переводов. \n";
                if (Successor != null)
                {
                    Successor.HandleRequest(paymentReceiver, Message);
                }
                else
                {
                    Message += "У пользователя отсутствует счёт для перевода! \n \n";
                    Debug.Log(Message);
                }
            }
            
            Message = null;
        }
    }
}