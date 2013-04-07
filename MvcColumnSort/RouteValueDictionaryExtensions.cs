using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace MvcColumnSort
{
    public static class RouteValueDictionaryExtensions
    {
        /// <summary>
        /// Gets the route value dictionary from a NameValueCollection usually the query string.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        public static RouteValueDictionary ToRouteValueDictionary(this NameValueCollection queryString)
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();

            if (queryString != null)
            {
                foreach (string key in queryString.AllKeys.Where(key => key != null))
                {
                    if (!routeValues.Keys.Contains(key))
                    {
                        // To handle the check box issues with mvc. However I don't really like it as this would cause 
                        // issues with things like check box lists.
                        // http://stackoverflow.com/questions/1102232/how-to-access-the-checkbox-value-in-asp-net-mvc-without-using-method-parameter
                        // http://forums.asp.net/t/1314753.aspx
                        string[] queryStringValues = queryString.GetValues(key);
                        if (queryStringValues != null)
                        {
                            routeValues[key] = queryStringValues.First();
                        }
                    }
                }
            }

            return routeValues;
        }
    }
}
