using Microsoft.AspNetCore.Mvc.ModelBinding;
using ValidationExample.Models;

namespace ValidationExample.CustomModelBinder
{
    public class PersonModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            Person person = new Person();
            // FirsNam and LastName
            if (bindingContext.ValueProvider.GetValue("FirstName").Length > 0) {
                person.PersonName = bindingContext.ValueProvider.GetValue("FirstName").FirstValue;
                if (bindingContext.ValueProvider.GetValue("LastName").Length > 0) {
                    person.PersonName += " " + bindingContext.ValueProvider.GetValue("LastName").FirstValue;
                }
            };

            if (bindingContext.ValueProvider.GetValue("Email").Length > 0) { 
                person.Email = bindingContext.ValueProvider.GetValue("LastName").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("Phone").Length > 0)
            {
                person.Phone = bindingContext.ValueProvider.GetValue("Phone").FirstValue;
            }

            if (bindingContext.ValueProvider.GetValue("Price").Length > 0)
            {
                person.Price = Convert.ToDouble(bindingContext.ValueProvider.GetValue("Price").FirstValue);
            }

            bindingContext.Result = ModelBindingResult.Success(person);
            return Task.CompletedTask;
        }
    }
}
