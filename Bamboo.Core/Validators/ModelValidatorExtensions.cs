using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bamboo.Core.Validators
{
    public static class ModelValidatorExtensions
    {
        /// <summary>
        ///     [Validator] Model Validator, Must after "AddMvc" 
        /// </summary>
        /// <param name="mvcBuilder"></param>
        /// <returns></returns>
        public static IMvcBuilder AddModelValidator(this IMvcBuilder mvcBuilder)
        {
            // Enable Microsoft.jQuery.Unobtrusive.Validation for Front-end
            mvcBuilder.AddViewOptions(options =>
            {
                options.HtmlHelperOptions.ClientValidationEnabled = true;
            });

            // Register Fluent Validation Rules
            mvcBuilder.AddFluentValidation(fvc =>
            {
                fvc.RegisterValidatorsFromAssemblyContaining<IModelValidator>();
            });

            return mvcBuilder;
        }
    }
}
