using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace TrimStringModelBinderSample
{
    public class TrimStringModelBinder : IModelBinder
    {
        private readonly IModelBinder FallbackBinder;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fallbackBinder"></param>        
        public TrimStringModelBinder(IModelBinder fallbackBinder)
        {
            FallbackBinder = fallbackBinder ?? throw new ArgumentNullException(nameof(fallbackBinder));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns></returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueProviderResult != null &&
              valueProviderResult.FirstValue is string str &&
              !string.IsNullOrEmpty(str))
            {
                bindingContext.Result = ModelBindingResult.Success(str.Trim());
                return Task.CompletedTask;
            }
            return FallbackBinder.BindModelAsync(bindingContext);
        }
    }
}