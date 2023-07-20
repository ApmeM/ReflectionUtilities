using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using ReflectionUtilities;
using System.Collections.Generic;
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

    private ExampleObject obj = new ExampleObject();

    [Benchmark]
    public void GetAndUseProperty_WithCache()
    {
        var reflectionType = ReflectionCache.GetReflection(typeof(ExampleObject));
        var property = reflectionType.Properties["Property2"];
        property.SetValue(obj, "test");
    }

    [Benchmark]
    public void GetAndUseProperty_Reflection()
    {
        var objType = typeof(ExampleObject);
        var property = objType.GetProperty("Property2");
        property.SetValue(obj, "test");
    }
}