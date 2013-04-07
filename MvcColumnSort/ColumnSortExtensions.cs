using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.UI.WebControls;

namespace MvcColumnSort
{
    /// <summary>
    /// The extensions to create a column sorting link
    /// </summary>
    public static class ColumnSortExtensions
    {
        /// <summary>
        /// Builds up an Action Link that handles the sorting based on the query string. 
        /// Column and Direction are the two default query string names.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="columnName">Name of the column to sort on.</param>
        /// <returns>A sorting anchor link</returns>
        public static MvcHtmlString SortActionLink(
            this HtmlHelper htmlHelper,
            string linkText,
            string actionName,
            string controllerName,
            string columnName)
        {
            return htmlHelper.SortActionLink(linkText, actionName, controllerName, columnName, string.Empty, null, null);
        }

        /// <summary>
        /// Builds up an Action Link that handles the sorting based on the query string.
        /// Column and Direction are the two default query string names.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="columnName">Name of the column to sort on.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns>A sorting anchor link</returns>
        public static MvcHtmlString SortActionLink(
            this HtmlHelper htmlHelper,
            string linkText,
            string actionName,
            string controllerName,
            string columnName,
            RouteValueDictionary routeValues)
        {
            return htmlHelper.SortActionLink(linkText, actionName, controllerName, columnName, string.Empty, routeValues, null);
        }

        /// <summary>
        /// Builds up an Action Link that handles the sorting based on the query string. 
        /// Column and Direction are the two default query string names.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="linkText">The link text.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="columnName">Name of the column to sort on.</param>
        /// <param name="queryStringPrefix">The query string prefix.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="htmlAttributes">The HTML attributes.</param>
        /// <returns>A sorting anchor link</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Globalization", "CA1304:SpecifyCultureInfo", MessageId = "System.String.ToLower", Justification = "Css is lower case.")]
        public static MvcHtmlString SortActionLink(
               this HtmlHelper htmlHelper,
               string linkText,
               string actionName,
               string controllerName,
               string columnName,
               string queryStringPrefix,
               RouteValueDictionary routeValues,
               IDictionary<string, object> htmlAttributes)
        {
            if (routeValues == null)
            {
                routeValues = new RouteValueDictionary();
            }

            // Needed? - I guess if there is a need to have sort on two tables on the same page.
            string columnKey = string.Format("{0}{1}", queryStringPrefix, "Column");
            string directionKey = string.Format("{0}{1}", queryStringPrefix, "Direction");

            SortDirection sortDirection = SortDirection.Ascending;
            string currentColumn = htmlHelper.ViewContext.HttpContext.Request.QueryString.Get(columnKey);

            if (columnName == currentColumn)
            {
                // Direction from the query string
                string currentDirection = htmlHelper.ViewContext.HttpContext.Request.QueryString.Get(directionKey);

                if (currentDirection != null)
                {
                    if (Enum.TryParse<SortDirection>(currentDirection, out sortDirection))
                    {
                        // Invert the direction
                        sortDirection = sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                    }
                }

                // Adding the default sort class. Should this be configurable?
                string sortClass = string.Format("sort {0}", sortDirection.ToString().ToLower());

                if (htmlAttributes == null)
                {
                    htmlAttributes = new Dictionary<string, object>();
                }

                if (!htmlAttributes.ContainsKey("class"))
                {
                    htmlAttributes.Add("class", sortClass);
                }
                else
                {
                    htmlAttributes["class"] = htmlAttributes["class"] + " " + sortClass;
                }
            }

            // This will only take route values that are part of what has been passed. 
            // This maybe quite limiting. The issue having is with checkboxes and how the ToRouteDictionary works on the query string
            RouteValueDictionary sortingRouteValues = htmlHelper.ViewContext.HttpContext.Request.QueryString.ToRouteValueDictionary();

            foreach (var keyValuePair in routeValues)
            {
                sortingRouteValues[keyValuePair.Key] = keyValuePair.Value;
            }

            sortingRouteValues[columnKey] = columnName;
            sortingRouteValues[directionKey] = sortDirection;

            return htmlHelper.ActionLink(linkText, actionName, controllerName, sortingRouteValues, htmlAttributes);

            /*
            // Unless we take from current query string this will only ever use the route dictionary
            routeValues[columnKey] = columnName;
            routeValues[directionKey] = sortDirection;

            return htmlHelper.ActionLink(linkText, actionName, controllerName, routeValues, htmlAttributes);
             */
        }
    }
}
