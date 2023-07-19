# Reflection Cache

## Introduction

Reflection in C# is very expensive operation especially when you use it often enough (For example creating your own ORM or pluginable system)

This small library help you to boost project speed using reflection cache. In this case system will use reflection only once, and then it will take data from memory.

## Installation and usage

Just add this sources to your solution (or include compiled dll)

To get list of special attributes you need to follow these semple steps:

    // 1. Get reflection class from cache (or if it is not in cache - reflect it and add to cache)
    var reflection = ReflectionCache.GetReflection(typeof(ExampleObject));
    // 2. Get list of attributes from cache
    var attributes = reflection.Attributes;
    // 3. Get attibutes by type
    var attributesByType = attributes[typeof(SomeType)];

Other available functions:

Cache:

1. static ReflectionClass GetReflection(Type t)

Class:

1. ReflectionAttributeList Attributes
2. Type BaseType
3. string FullName
4. ReflectionMethodList Methods
5. string Name
6. ReflectionPropertyList Properties
7. bool IsAssignableFrom(Type type)

Method:

1. string FullName
2. string Name
3. string WithClassName
4. ParameterInfo[] Parameters
5. ReflectionAttributeList Attributes
6. Type ReturnType
7. object Invoke(object obj, params object[] param)

Property:

1. ReflectionAttributeList Attributes
2. string FullName
3. string Name
4. Type PropertyType
5. string WithClassName
6. object GetValue(object from)
7. void SetValue(object to, object what)
