﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ShibaInu_PointerScalerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ShibaInu.PointerScaler), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("UpdateScale", UpdateScale);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("normalScale", get_normalScale, set_normalScale);
		L.RegVar("downScale", get_downScale, set_downScale);
		L.RegVar("enterScale", get_enterScale, set_enterScale);
		L.RegVar("tweenDuration", get_tweenDuration, set_tweenDuration);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int UpdateScale(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)ToLua.CheckObject<ShibaInu.PointerScaler>(L, 1);
				obj.UpdateScale();
				return 0;
			}
			else if (count == 2)
			{
				ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)ToLua.CheckObject<ShibaInu.PointerScaler>(L, 1);
				System.Nullable<UnityEngine.Vector3> arg0 = ToLua.CheckNullable<UnityEngine.Vector3>(L, 2);
				obj.UpdateScale(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ShibaInu.PointerScaler.UpdateScale");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_normalScale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			UnityEngine.Vector3 ret = obj.normalScale;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index normalScale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_downScale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			float ret = obj.downScale;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index downScale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_enterScale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			float ret = obj.enterScale;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enterScale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_tweenDuration(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			float ret = obj.tweenDuration;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index tweenDuration on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_normalScale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			UnityEngine.Vector3 arg0 = ToLua.ToVector3(L, 2);
			obj.normalScale = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index normalScale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_downScale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.downScale = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index downScale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_enterScale(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.enterScale = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index enterScale on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_tweenDuration(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.PointerScaler obj = (ShibaInu.PointerScaler)o;
			float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
			obj.tweenDuration = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index tweenDuration on a nil value");
		}
	}
}

