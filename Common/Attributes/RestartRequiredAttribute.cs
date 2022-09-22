using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attributes
{
	[AttributeUsage(AttributeTargets.Property |
						  AttributeTargets.Field)]
	public class RestartRequiredAttribute : Attribute
	{
	}
}
