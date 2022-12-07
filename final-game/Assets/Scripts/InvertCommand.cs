using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertCommand : ICommand
{
    ReticleController _controller;
    public InvertCommand(ReticleController c)
    {
        _controller = c;
    }
    public void Execute()
    {
        _controller.SetInverted();
    }
}
