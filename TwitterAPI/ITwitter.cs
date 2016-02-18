﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter
{
	public interface ITwitter
	{
		Task<bool> Authenticate();
		Task GetHomeTimeline();
	}
}
