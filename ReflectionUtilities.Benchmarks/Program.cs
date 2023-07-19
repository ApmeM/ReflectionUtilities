using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ReflectionUtilities;
using System.Collections.Generic;
using System.Linq;
using System;

[MemoryDiagnoser]
public class Program
{
    public class ExampleObject
    {
        [Custom]
        [Custom]
        [Custom]
        [Custom]
        public object Property2 { get; set; } = 1;
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class CustomAttribute : Attribute
    {
    }

    public static void Main(string[] args)
    {
        BenchmarkRunner.Run<Program>();
    }

    [Benchmark]
    public void UseReflectionCache()
    {
        var type = ReflectionCache.GetReflection(typeof(ExampleObject));
        var property = type.Properties["Property2"];
        ExampleObject obj = new ExampleObject();
        property.SetValue(obj, "test string");
        var value = property.GetValue(obj);
        var attributes = property.Attributes;
    }

    [Benchmark]
    public void RegularReflection()
    {
        var type = typeof(ExampleObject);
        var property = type.GetProperties().Where(a => a.Name == "Property2").Single();
        ExampleObject obj = new ExampleObject();
        property.SetValue(obj, "test string");
        property.GetValue(obj);
        property.GetCustomAttributes(true);
    }
}