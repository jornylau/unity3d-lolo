﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class ShibaInu_HttpDownloadWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(ShibaInu.HttpDownload), typeof(System.Object));
		L.RegFunction("SetProxy", SetProxy);
		L.RegFunction("SetLuaCallback", SetLuaCallback);
		L.RegFunction("Start", Start);
		L.RegFunction("Abort", Abort);
		L.RegFunction("New", _CreateShibaInu_HttpDownload);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("url", get_url, set_url);
		L.RegVar("savePath", get_savePath, set_savePath);
		L.RegVar("timeout", get_timeout, set_timeout);
		L.RegVar("callback", get_callback, set_callback);
		L.RegVar("downloading", get_downloading, null);
		L.RegVar("progress", get_progress, null);
		L.RegVar("speed", get_speed, null);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateShibaInu_HttpDownload(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				ShibaInu.HttpDownload obj = new ShibaInu.HttpDownload();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: ShibaInu.HttpDownload.New");
			}
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetProxy(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)ToLua.CheckObject<ShibaInu.HttpDownload>(L, 1);
			string arg0 = ToLua.CheckString(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			obj.SetProxy(arg0, arg1);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SetLuaCallback(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)ToLua.CheckObject<ShibaInu.HttpDownload>(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 2);
			obj.SetLuaCallback(arg0);
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Start(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)ToLua.CheckObject<ShibaInu.HttpDownload>(L, 1);
			obj.Start();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Abort(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)ToLua.CheckObject<ShibaInu.HttpDownload>(L, 1);
			obj.Abort();
			return 0;
		}
		catch (Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_url(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			string ret = obj.url;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index url on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_savePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			string ret = obj.savePath;
			LuaDLL.lua_pushstring(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index savePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_timeout(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			int ret = obj.timeout;
			LuaDLL.lua_pushinteger(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index timeout on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_callback(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			System.Action<int,string> ret = obj.callback;
			ToLua.Push(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index callback on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_downloading(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			bool ret = obj.downloading;
			LuaDLL.lua_pushboolean(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index downloading on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_progress(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			float ret = obj.progress;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index progress on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_speed(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			uint ret = obj.speed;
			LuaDLL.lua_pushnumber(L, ret);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index speed on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_url(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.url = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index url on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_savePath(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			string arg0 = ToLua.CheckString(L, 2);
			obj.savePath = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index savePath on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_timeout(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			obj.timeout = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index timeout on a nil value");
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_callback(IntPtr L)
	{
		object o = null;

		try
		{
			o = ToLua.ToObject(L, 1);
			ShibaInu.HttpDownload obj = (ShibaInu.HttpDownload)o;
			System.Action<int,string> arg0 = (System.Action<int,string>)ToLua.CheckDelegate<System.Action<int,string>>(L, 2);
			obj.callback = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e, o, "attempt to index callback on a nil value");
		}
	}
}

