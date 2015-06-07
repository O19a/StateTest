using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    public class Transaction
    {
        public ITransactionState transactionState{get; set;}
        // a lot of transaction attributes
        // ...
        //
        public string transactionPublicId { get; set; }
        public DateTime createdTime { get; set; }
        
        public Transaction()
        {
            createdTime = DateTime.Now;
            transactionPublicId = GetTransactionPublicId();
            transactionState = new CreatedState(this);
            //
            //save to DB
            Save();
        }
        public override string ToString()
        {
            return "Transaction state is \"" + transactionState;
        }

        public void ChangeStateToPartialApproved()
        {
            transactionState.ChangeState(this, TransactionState.PartialApproved);
        }

        public void ChangeStateToApproved()
        {
            transactionState.ChangeState(this, TransactionState.Approved);
        }

        public void ChangeStateToRejected()
        {
            transactionState.ChangeState(this, TransactionState.Rejected);
        }

        private void Save()
        {
            Console.WriteLine("Save [to DB]");
        }

        private string GetTransactionPublicId()
        {
            return "123";
        }
    }
}
