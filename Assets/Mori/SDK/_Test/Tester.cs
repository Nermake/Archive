using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Mori.SDK._Test
{
    public class Tester : MonoBehaviour
    {
        private async void Start()
        {
            Account account = new Account();
            account.Added += PrintAsync;
 
            account.Put(500);
 
            await Task.Delay(2000); // ждем завершения
        }
        
        // определение асинхронного метода
        async void PrintAsync(object? obj, string message)
        {
            await Task.Delay(1000); // имитация продолжительной работы
            Debug.Log(message);
        }

    }
    
    class Account
    {
        int sum = 0;
        public event EventHandler<string>? Added;
        public void Put(int sum)
        {
            this.sum += sum;
            Added?.Invoke(this, $"На счет поступило {sum} $");
        }
    }
}