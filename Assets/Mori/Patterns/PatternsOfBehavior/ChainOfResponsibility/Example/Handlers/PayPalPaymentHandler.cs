using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example
{
    public class PayPalPaymentHandler : PaymentHandler
    {
        public override void HandleRequest(PaymentReceiver paymentReceiver, string message)
        {
            Message += message;
            Message += "Выполняем перевод через PayPal... \n";
                
            if (paymentReceiver.PayPalTransfer)
            {
                Message += "    Перевод выполнен успешно! \n";
                Debug.Log(Message);
            }
            else
            {
                Message += "    Не удалось выполнить перевод через PayPal. \n";
                
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