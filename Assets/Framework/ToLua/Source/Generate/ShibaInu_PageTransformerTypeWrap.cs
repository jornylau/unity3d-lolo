﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ShibaInu_PageTransformerTypeWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(ShibaInu.PageTransformerType));
		L.RegVar("Scroll", get_Scroll, null);
		L.RegVar("Fade", get_Fade, null);
		L.RegVar("ZoomOut", get_ZoomOut, null);
		L.RegVar("Depth", get_Depth, null);
		L.RegFunction("IntToEnum", IntToEnum);
		L.EndEnum();
		TypeTraits<ShibaInu.PageTransformerType>.Check = CheckType;
		StackTraits<ShibaInu.PageTransformerType>.Push = Push;
	}

	static void Push(IntPtr L, ShibaInu.PageTransformerType arg)
	{
		ToLua.Push(L, arg);
	}

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(typeof(ShibaInu.PageTransformerType), L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Scroll(IntPtr L)
	{
		ToLua.Push(L, ShibaInu.PageTransformerType.Scroll);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Fade(IntPtr L)
	{
		ToLua.Push(L, ShibaInu.PageTransformerType.Fade);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_ZoomOut(IntPtr L)
	{
		ToLua.Push(L, ShibaInu.PageTransformerType.ZoomOut);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Depth(IntPtr L)
	{
		ToLua.Push(L, ShibaInu.PageTransformerType.Depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tonumber(L, 1);
		ShibaInu.PageTransformerType o = (ShibaInu.PageTransformerType)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}
