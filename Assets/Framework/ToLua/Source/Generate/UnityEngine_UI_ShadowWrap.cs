﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_UI_ShadowWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(UnityEngine.UI.Shadow), typeof(UnityEngine.UI.BaseMeshEffect));
		L.RegFunction("ModifyMesh", ModifyMesh);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("effectColor", get_effectColor, set_effectColor);
		L.RegVar("effectDistance", get_effectDistance, set_effectDistance);
		L.RegVar("useGraphicAlpha", get_useGraphicAlpha, set_useGraphicAlpha);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int ModifyMesh(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes<UnityEngine.UI.VertexHelper>(L, 2))
			{
				UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)ToLua.CheckObject<UnityEngine.UI.Shadow>(L, 1);
				UnityEngine.UI.VertexHelper arg0 = (UnityEngine.UI.VertexHelper)ToLua.ToObject(L, 2);
				obj.ModifyMesh(arg0);
				return 0;
			}
			else if (count == 2 && TypeChecker.CheckTypes<UnityEngine.Mesh>(L, 2))
			{
				UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)ToLua.CheckObject<UnityEngine.UI.Shadow>(L, 1);
				UnityEngine.Mesh arg0 = (UnityEngine.Mesh)ToLua.ToObject(L, 2);
				obj.ModifyMesh(arg0);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: UnityEngine.UI.Shadow.ModifyMesh");
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
	static int get_effectColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)o;
			UnityEngine.Color ret = obj.effectColor;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index effectColor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_effectDistance(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)o;
			UnityEngine.Vector2 ret = obj.effectDistance;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index effectDistance on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_useGraphicAlpha(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)o;
			bool ret = obj.useGraphicAlpha;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index useGraphicAlpha on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectColor(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)o;
			UnityEngine.Color arg0 = ToLua.ToColor(L, 2);
			obj.effectColor = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index effectColor on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_effectDistance(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)o;
			UnityEngine.Vector2 arg0 = ToLua.ToVector2(L, 2);
			obj.effectDistance = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index effectDistance on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_useGraphicAlpha(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			UnityEngine.UI.Shadow obj = (UnityEngine.UI.Shadow)o;
			bool arg0 = LuaDLL.luaL_checkboolean(L, 2);
			obj.useGraphicAlpha = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index useGraphicAlpha on a nil value");
		}
	}
}

