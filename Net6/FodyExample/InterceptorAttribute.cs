﻿using MethodDecorator.Fody.Interfaces;
using Serilog;
using System.Reflection;

[AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Module)]
public class InterceptorAttribute : Attribute, IMethodDecorator
{
    public void Init(object instance, MethodBase method, object[] args)
    {
        Console.WriteLine("Before method execution");
        Log.Information("instance {@instance}", instance);
        //var paramss = method.;
        //foreach (var param2 in paramss)
        //{
        //    Log.Information("param2 {@param2}", param2);
        //}

        foreach (var arg in args)
        {
            Log.Information("param2 {@arg} {@param2}", arg.GetType(), arg);
        }
    }

    public void OnEntry()
    {
        Console.WriteLine("OnEntry method execution");
    }

    public void OnExit()
    {
        Console.WriteLine("OnExit method execution");
    }

    public void OnException(Exception exception)
    {
    }
}
