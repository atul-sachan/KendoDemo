using System;
using KendoDemo.API.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace KendoDemo.API
{
    public class KendoModelBuilder
    {
        public IEdmModel GetEdmModel(IServiceProvider serviceProvider)
        {
            var builder = new ODataConventionModelBuilder(serviceProvider);

            builder.EntitySet<Kendo>(nameof(Kendo))
                            .EntityType
                            .Filter() // Allow for the $filter Command
                            .Count() // Allow for the $count Command
                            .Expand() // Allow for the $expand Command
                            .OrderBy() // Allow for the $orderby Command
                            .Page() // Allow for the $top and $skip Commands
                            .Select();// Allow for the $select Command; 

            return builder.GetEdmModel();
        }
    }
}
