using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example
{
    public class BankPaymentHandler : PaymentHandler
    {
        public override void HandleRequest(PaymentReceiver paymentReceiver, string message)
        {
            Message += message;
            Message += "Выполняем банковский перевод... \n";
                
            if (paymentReceiver.BankTransfer)
            {
                Message += "    Перевод выполнен успешно! \n";
                Debug.Log(Message);
            }
            else
            {
                Message += "    Не удалось выполнить банковский перевод. \n";
                
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