using System;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example1
{
    public class MainScript : MonoBehaviour
    {
        private void Start()
        {
            PaymentHandler bankPaymentHandler = new BankPaymentHandler();
            PaymentHandler paypalPaymentHandler = new PayPalPaymentHandler();
            PaymentHandler moneyPaymentHandler = new MoneyPaymentHandler();

            bankPaymentHandler.Successor = paypalPaymentHandler;
            paypalPaymentHandler.Successor = moneyPaymentHandler;
            
            PaymentReceiver paymentReceiver_1 = new PaymentReceiver();
            paymentReceiver_1.Name = "uwu";
            paymentReceiver_1.BankTransfer = false;
            paymentReceiver_1.PayPalTransfer = true;
            paymentReceiver_1.MoneyTransfer = false;
            
            PaymentReceiver paymentReceiver_2 = new PaymentReceiver();
            paymentReceiver_2.Name = "qwe";
            paymentReceiver_2.BankTransfer = false;
            paymentReceiver_2.PayPalTransfer = false;
            paymentReceiver_2.MoneyTransfer = true;
            
            PaymentReceiver paymentReceiver_3 = new PaymentReceiver();
            paymentReceiver_3.Name = "zxc";
            paymentReceiver_3.BankTransfer = true;
            paymentReceiver_3.PayPalTransfer = true;
            paymentReceiver_3.MoneyTransfer = false;
            
            bankPaymentHandler.HandleRequest(paymentReceiver_1, $"Перевод для : {paymentReceiver_1.Name} \n");
            bankPaymentHandler.HandleRequest(paymentReceiver_2, $"Перевод для : {paymentReceiver_2.Name} \n");
            bankPaymentHandler.HandleRequest(paymentReceiver_3, $"Перевод для : {paymentReceiver_3.Name} \n");
        }
    }
}