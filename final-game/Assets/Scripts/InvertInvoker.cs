using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertInvoker : MonoBehaviour
{
     Stack<ICommand> _commands;

    public InvertInvoker()
    {
        _commands = new Stack<ICommand>();
    }

    public void AddCommand(ICommand newCommand)
    {
        newCommand.Execute();
        _commands.Push(newCommand);
    }
}
