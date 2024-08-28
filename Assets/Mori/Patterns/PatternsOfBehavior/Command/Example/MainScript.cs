using System;
using UnityEngine;

namespace Mori.Patterns.PatternsOfBehavior.Command.Example
{
    public class MainScript : MonoBehaviour
    {
        private Client _client;
        private void Start()
        {
            _client = new Client();
            _client.Main();
        }
    }
    
    /// <summary>
    /// Main interface of commands
    /// </summary>
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    
    /// <summary>
    /// An example of a specific command.
    /// 
    /// Execute() - calling a function with logic in the receiver.
    /// Undo() - canceling a function with logic in the receiver.
    /// </summary>
    class ConcreteCommand : ICommand
    {
        private readonly Receiver _receiver;
        
        public ConcreteCommand(Receiver r)
        {
            _receiver = r;
        }
        
        public void Execute()
        {
            _receiver.Operation_On();
        }

        public void Undo()
        {
            _receiver.Operation_Off();
        }
    }
    
    /// <summary>
    /// An object with logic.
    /// </summary>
    class Receiver
    {
        public void Operation_On()
        {
            Debug.Log("Log On");
        }

        public void Operation_Off()
        {
            Debug.Log("Log Off");
        }
    }
    
    /// <summary>
    /// An object that starts and cancels commands.
    /// </summary>
    class Invoker
    {
        private ICommand _command;
        public void SetCommand(ICommand c)
        {
            _command = c;
        }
        public void Run()
        {
            _command.Execute();
        }
        public void Cancel()
        {
            _command.Undo();
        }
    }
    
    /// <summary>
    /// An object that puts receivers into commands.
    /// </summary>
    class Client
    {
        private Invoker _invoker;
        private Receiver _receiver;
        
        public void Main()
        {
            _invoker = new Invoker();
            _receiver = new Receiver();
            
            ConcreteCommand command = new ConcreteCommand(_receiver);
            
            _invoker.SetCommand(command);
            _invoker.Run();
        }
    }
}