using Library.Domain.Interfaces;
using Library.Domain.Services;
using Library.Domain;
using Microsoft.AspNetCore.OData.Query.Validator;
using Microsoft.AspNetCore.OData.Query;

namespace Library.WebAPI
{
    public static class ServicesExtension
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IInvertWordService, InvertWordService>();
            services.AddScoped<ISearchService, SearchService>();

            var oataSettings = new ODataValidationSettings()
            {
                AllowedFunctions = AllowedFunctions.Contains,
                AllowedLogicalOperators = AllowedLogicalOperators.And | AllowedLogicalOperators.Or | AllowedLogicalOperators.Equal,
                AllowedArithmeticOperators = AllowedArithmeticOperators.None,
                AllowedQueryOptions = AllowedQueryOptions.Filter | AllowedQueryOptions.Select
            };

            services.AddSingleton(oataSettings);
        }
    }
}
