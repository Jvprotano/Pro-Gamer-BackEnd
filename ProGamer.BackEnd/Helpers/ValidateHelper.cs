using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProGamer.BackEnd.Helpers
{
    public static class ValidateHelper
    {
        public static void ValidateModel(this object model)
        {
            var context = new ValidationContext(model, null, null);
            var errorsList = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, errorsList, true);
            if (errorsList.Count > 0)
            {
                throw new ValidationException(errorsList[0].ErrorMessage);
            }
        }
    }
}