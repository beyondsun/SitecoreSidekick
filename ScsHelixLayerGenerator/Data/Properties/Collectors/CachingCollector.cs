﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScsHelixLayerGenerator.Data.Properties.Collectors
{
	public class CachingCollector : IPropertyCollector
	{
		public string Id {get;set;} 
		public string Name {get;set;} 
		public string Description {get;set;} 
		public string Value {get;set;} 
		public string Values {get;set;} 

		public string AngularMarkup { get
			{
				var options = new List<String>{
					"Cacheable",
					"Clear on Index Update",
					"Vary By Data",
					"Vary By Device",
					"Vary By Login",
					"Vary By Parm",
					"Vary By Query String",
					"Vary By User" }.Aggregate(new StringBuilder(), (running, x)=> running.Append($"<option value='{x}'>{x}</option>")).ToString();
				return @"
<div ng-if=""vm.propertyMap['_CREATERENDERING_'].Value"">
	<h4>
		{{property.Name}}
	</h4>
	<a ng-mouseover=""property.showdescription = true"" ng-mouseleave=""property.showdescription = false"">?</a>
	<select multiple ng-model=""property.Value"">" + options + @"</select>
	<div ng-if=""property.showdescription"">{{property.Description}}</div>
</div>";

			} }

		public string Processor { get; set; } = "CacheOptions";

		public bool Validate(string value)
		{
			return true;
		}
	}
}
