﻿//      )                             *     
//   ( /(        *   )       (      (  `    
//   )\()) (   ` )  /( (     )\     )\))(   
//  ((_)\  )\   ( )(_)))\ ((((_)(  ((_)()\  
// __ ((_)((_) (_(_())((_) )\ _ )\ (_()((_) 
// \ \ / / (_) |_   _|| __|(_)_\(_)|  \/  | 
//  \ V /  | | _ | |  | _|  / _ \  | |\/| | 
//   |_|   |_|(_)|_|  |___|/_/ \_\ |_|  |_| 
// 
// This file is subject to the terms and conditions defined in
// file 'License.txt', which is part of this source code package.
// 
// Copyright © Yi.TEAM. All rights reserved.
// -------------------------------------------------------------------------------

using System;

namespace Yisoft.Crontab.Filters
{
	/// <summary>
	///     Handles the filter instance where the user specifies a * (for any value)
	/// </summary>
	public class AnyFilter : ICronFilter, ITimeFilter
	{
		/// <summary>
		/// Constructs a new AnyFilter instance
		/// </summary>
		/// <param name="kind">The crontab field kind to associate with this filter</param>
		public AnyFilter(CrontabFieldKind kind)
		{
			Kind = kind;
		}

		public CrontabFieldKind Kind { get; }

		/// <summary>
		/// Checks if the value is accepted by the filter
		/// </summary>
		/// <param name="value">The value to check</param>
		/// <returns>True if the value matches the condition, False if it does not match.</returns>
		public bool IsMatch(DateTime value)
		{
			return true;
		}

		public int? Next(int value)
		{
			var max = Constants.MaximumDateTimeValues[Kind];
			if (Kind == CrontabFieldKind.Day
			    || Kind == CrontabFieldKind.Month
			    || Kind == CrontabFieldKind.DayOfWeek) throw new CrontabException("Cannot call Next for Day, Month or DayOfWeek types");

			var newValue = (int?) value + 1;

			if (newValue >= max) newValue = null;

			return newValue;
		}

		public int First()
		{
			if (Kind == CrontabFieldKind.Day
			    || Kind == CrontabFieldKind.Month
			    || Kind == CrontabFieldKind.DayOfWeek) throw new CrontabException("Cannot call First for Day, Month or DayOfWeek types");

			return 0;
		}

		public override string ToString() { return "*"; }
	}
}
