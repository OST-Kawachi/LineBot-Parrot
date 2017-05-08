﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace Parrot.Helper {

	/// <summary>
	/// 非同期処理を同期処理で行えるヘルパークラス
	/// </summary>
	internal static class AsyncHelper {

		private static readonly TaskFactory _myTaskFactory = new TaskFactory( CancellationToken.None , TaskCreationOptions.None , TaskContinuationOptions.None , TaskScheduler.Default );

		public static TResult RunSync<TResult>( Func<Task<TResult>> func ) {
			return AsyncHelper._myTaskFactory.StartNew<Task<TResult>>( func ).Unwrap<TResult>().GetAwaiter().GetResult();
		}

		public static void RunSync( Func<Task> func ) {
			AsyncHelper._myTaskFactory.StartNew<Task>( func ).Unwrap().GetAwaiter().GetResult();
		}

	}

}