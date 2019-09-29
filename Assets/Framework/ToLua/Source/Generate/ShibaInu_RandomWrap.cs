﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ShibaInu_RandomWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ShibaInu.Random), typeof(System.Object));
		L.RegFunction("Next", Next);
		L.RegFunction("NextFloat", NextFloat);
		L.RegFunction("Chance", Chance);
		L.RegFunction("New", _CreateShibaInu_Random);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("Seed", get_Seed, set_Seed);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateShibaInu_Random(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				ShibaInu.Random obj = new ShibaInu.Random();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else if (count == 1)
			{
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 1);
				ShibaInu.Random obj = new ShibaInu.Random(arg0);
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: ShibaInu.Random.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Next(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				int o = obj.Next();
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 2)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				int o = obj.Next(arg0);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else if (count == 3)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
				int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
				int o = obj.Next(arg0, arg1);
				LuaDLL.lua_pushinteger(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ShibaInu.Random.Next");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int NextFloat(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				float o = obj.NextFloat();
				LuaDLL.lua_pushnumber(L, o);
				return 1;
			}
			else if (count == 2)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
				float o = obj.NextFloat(arg0);
				LuaDLL.lua_pushnumber(L, o);
				return 1;
			}
			else if (count == 3)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
				float o = obj.NextFloat(arg0, arg1);
				LuaDLL.lua_pushnumber(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ShibaInu.Random.NextFloat");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Chance(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 1)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				bool o = obj.Chance();
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 2)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
				bool o = obj.Chance(arg0);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else if (count == 3)
			{
				ShibaInu.Random obj = (ShibaInu.Random)ToLua.CheckObject<ShibaInu.Random>(L, 1);
				float arg0 = (float)LuaDLL.luaL_checknumber(L, 2);
				float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
				bool o = obj.Chance(arg0, arg1);
				LuaDLL.lua_pushboolean(L, o);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: ShibaInu.Random.Chance");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Seed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.Random obj = (ShibaInu.Random)o;
			int ret = obj.Seed;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Seed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_Seed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.Random obj = (ShibaInu.Random)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.Seed = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index Seed on a nil value");
		}
	}
}

