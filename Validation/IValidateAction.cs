﻿namespace MFramework.Domain.Validation
{
    public interface IValidateAction<TValidatable> where TValidatable : class,IValidatable
    {
        void FailureOnValidation(TValidatable validatable, IValidateFailure f);
    }
}
