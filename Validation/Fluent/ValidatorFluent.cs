using System;
using System.Linq.Expressions;
using FluentValidation;

namespace MFramework.Domain.Validation.Fluent
{
    public  abstract class ValidatorFluent<TValidatable> :ValidatorBase<TValidatable> where TValidatable : class,IValidatable
    {
        #region Attributes

        private AbstractValidator<TValidatable> _validator;
        #endregion
        #region Constructor

        protected ValidatorFluent()
        {
            _validator = new InlineValidator<TValidatable>();
            
        }
        #endregion
        #region Protected Interface
        protected void AddRules(IValidationRule r)
        {
            _validator.AddRule(r);
        }
        protected IRuleBuilderInitial<TValidatable, TProperty> RuleFor<TProperty>(Expression<Func<TValidatable, TProperty>> expression)
        {
            return(_validator.RuleFor(expression));
        }

        #endregion
        public override IValidateResult DoValidate(TValidatable t)
        {
            return (new ValidateResultFluent(_validator.Validate(t)));
        
        }
        
    }
}
