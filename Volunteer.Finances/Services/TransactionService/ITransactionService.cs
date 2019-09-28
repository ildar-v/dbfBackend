using System;

namespace Volunteer.Finances.Services.TransactionService
{
    public interface ITransactionService
    {
        bool Deposit(decimal amount, Guid fundUid);

        bool Withdrow(decimal amount, Guid fundUid);
    }
}
