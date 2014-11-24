using MFramework.Domain.Validation;
using MFramework.Domain.Validation.Castle;
using MFramework.Domain.Validation.Composite;
using MFramework.Domain.Validation.DataAnnotations;
using MFramework.Domain.Validation.Fluent;

namespace MFramework.Domain.DomainEntity.Validation
{
    public  abstract class EntityValidatorBase<TEntity> :ValidatorFluent<TEntity> where TEntity : Entity<TEntity>
    {
        #region Members Variable

        private ValidatorComposite<TEntity> _v;
        private bool _onValidationCall; 
        #endregion
#region constructors
        protected EntityValidatorBase()
        {
            _v = new ValidatorComposite<TEntity>(new IValidator<TEntity>[] {this,new ValidatorDataAnnotation<TEntity>(),new ValidatorCastle<TEntity>() });
            _onValidationCall = false;
        }
#endregion
        public override IValidateResult DoValidate(TEntity t)
        {
            if (!_onValidationCall)
            {
                _onValidationCall = !_onValidationCall;
                return (_v.Validate(t));
            }
            _onValidationCall = !_onValidationCall;
            return(base.DoValidate(t));
        }
    }
}
