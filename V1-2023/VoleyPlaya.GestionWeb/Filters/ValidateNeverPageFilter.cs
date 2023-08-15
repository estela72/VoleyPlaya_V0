using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Reflection;
using System.Linq;

public class ValidateNeverPageFilter : IPageFilter
{
    public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
    {
    }

    public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
    {
        var propertyInfo = context.HandlerMethod.MethodInfo.DeclaringType?.GetProperty("Model")?.PropertyType.GetProperty("PropertyName");
        if (propertyInfo != null)
        {
            var propertyAttributes = propertyInfo.GetCustomAttributesData();

            if (propertyAttributes.Any(x => x.AttributeType == typeof(ValidateNeverAttribute)))
            {
                context.ModelState.Remove("PropertyName");
            }
        }
    }

    public void OnPageHandlerSelected(PageHandlerSelectedContext context)
    {
    }
}