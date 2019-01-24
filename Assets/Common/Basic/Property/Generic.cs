using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class Generic
{

	public static bool IsSerialInterface(System.Type type)
	{
		return typeof(SriaHolderInterface).IsAssignableFrom(type);
	}


	public static bool IsAddCallBackInterface<T>()
	{
		return typeof(AddCallBackInterface).IsAssignableFrom(typeof(T));
	}

	public static bool IsAddCallBackInterface(System.Type type)
	{
		return typeof(AddCallBackInterface).IsAssignableFrom(type);
	}
		
	/*public static bool InheritsOrImplements(this Type child, Type parent)
	{
		parent = ResolveGenericTypeDefinition(parent);

		var currentChild = child.IsGenericType
			? child.GetGenericTypeDefinition()
			: child;

		while (currentChild != typeof (object))
		{
			if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
				return true;

			currentChild = currentChild.BaseType != null
				&& currentChild.BaseType.IsGenericType
				? currentChild.BaseType.GetGenericTypeDefinition()
				: currentChild.BaseType;

			if (currentChild == null)
				return false;
		}
		return false;
	}

	private static bool HasAnyInterfaces(Type parent, Type child)
	{
		return child.GetInterfaces()
			.Any(childInterface =>
				{
					var currentInterface = childInterface.IsGenericType
						? childInterface.GetGenericTypeDefinition()
						: childInterface;

					return currentInterface == parent;
				});
	}

	private static Type ResolveGenericTypeDefinition(Type parent)
	{
		var shouldUseGenericType = true;
		if (parent.IsGenericType && parent.GetGenericTypeDefinition() != parent)
			shouldUseGenericType = false;

		if (parent.IsGenericType && shouldUseGenericType)
			parent = parent.GetGenericTypeDefinition();
		return parent;
	}*/
}