using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipesAndFiltersRabbitMQ
{
	public class Filter
	{
		public string MessageTransform(string message)
		{
			return message + ";1stFilter";
		}
	}
}
