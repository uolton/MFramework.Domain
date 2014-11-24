using MFramework.Domain.Validation;

namespace MFramework.Domain.Objects
{
     
    public   abstract class ValidatableBaseObject<TValidatable> : BaseObject,IValidatable
        where TValidatable : ValidatableBaseObject<TValidatable>
        //where TValidator : IValidator<TValidatable>
    {
        #region Attributes
       protected IValidator<TValidatable> _validator;
        #endregion
        
        #region constructors
       protected ValidatableBaseObject(IValidator<TValidatable> validator)
        {
            _validator = validator;
        }
    #endregion
       #region  IEntity Interface
       public bool IsValid() {return Validate().IsValid;} 
         
         public IValidateResult  Validate()
            {
                return (_validator.Validate(this as TValidatable)); 
            }
        #endregion
        
    }
}
