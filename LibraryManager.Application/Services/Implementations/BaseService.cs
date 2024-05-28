using LibaryManager.Core.Entities;
using LibraryManager.Application.Notifications;
using LibraryManager.Core.Interfaces;
using FluentValidation;
using FluentValidation.Results;

namespace LibraryManager.Application.Services.Implementations;

public abstract class BaseService
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly INotificator _notificator;

    public BaseService(IUnitOfWork unitOfWork, INotificator notificator)
    {
        _unitOfWork = unitOfWork;
        _notificator = notificator;
    }

    protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : BaseEntity
    {
        var validator = validation.Validate(entity);
        if (validator.IsValid) return true;

        NotifyError(validator);

        return false;
    }

    protected void NotifyError(string message)
    {
        _notificator.Handle(new Notification(message));
    }

    protected void NotifyError(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            NotifyError(error.ErrorMessage);
        }
    }

    protected async Task<bool> CommitAsync()
    {
        return await _unitOfWork.CommitAsync();
    }
}
