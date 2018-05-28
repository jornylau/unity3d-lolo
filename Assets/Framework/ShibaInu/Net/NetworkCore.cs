﻿using System;


namespace ShibaInu
{


	/// <summary>
	/// Http 请求方式常量
	/// </summary>
	public class HttpRequestMethod
	{
		/// POST
		public const string POST = "POST";
		/// GET
		public const string GET = "GET";
		/// 只获取 response handers (content length)
		public const string HEAD = "HEAD";
	}


	/// <summary>
	/// Http 请求异常状态码常量
	/// </summary>
	public class HttpExceptionStatusCode
	{
		/// 创建线程时发生异常
		public const int CREATE_THREAD = -1;
		/// 发送请求时发生异常
		public const int SEND_REQUEST = -2;
		/// 获取内容时发生异常
		public const int GET_RESPONSE = -3;
		/// 发送请求或获取内容过程中被取消了
		public const int ABORTED = -4;
		/// 获取目标文件大小时发生异常
		public const int GET_HEAD = -5;
	}




	/// <summary>
	/// Socket 相关事件常量
	/// </summary>
	public class SocketEvent
	{
		/// 连接成功
		public const string CONNECTED = "SocketEvent_Connected";
		/// 连接失败
		public const string CONNECT_FAIL = "SocketEvent_ConnectFail";
		/// 断开连接
		public const string DISCONNECT = "SocketEvent_Disconnect";
		/// 收到消息
		public const string MESSAGE = "SocketEvent_Message";
	}


	/// <summary>
	/// Socket 消息协议接口
	/// </summary>
	public interface IMsgProtocol
	{
		/// 收到消息的回调。Receive() 解包出一条消息时的回调
		Action<System.Object> onMessage{ set; get; }

		/// 接收数据，处理粘包，根据协议解析出消息，并回调 messageCallback
		void Receive (byte[] buffer, int length);

		/// 重置（清空）已收到的数据包。在连接关闭时会被 TcpSocketClient 调用
		void Reset ();

		/// 根据协议编码 data，并返回编码后的字节数组
		byte[] Encode (System.Object data);
	}



}

