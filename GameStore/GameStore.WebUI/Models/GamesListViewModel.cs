﻿using GameStore.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GameStore.WebUI.Models
{
	public class GamesListViewModel
	{
		public IEnumerable<Game> Games { get; set; }
		public PagingInfo PagingInfo { get; set; }
	}
}