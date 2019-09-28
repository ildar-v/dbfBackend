using System;

namespace Volunteer.Finances.Services.TransactionService
{
    public class SimpleTransactionService : ITransactionService
    {
        public bool Deposit(decimal amount, Guid fundUid)
        {
            throw new NotImplementedException();
        }

        public bool Withdrow(decimal amount, Guid fundUid)
        {
            throw new NotImplementedException();
        }
    }
}
