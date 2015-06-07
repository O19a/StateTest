using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    public enum TransactionState 
    { 
        Created = 1,
        PartialApproved = 2,
        Approved = 3,
        Rejected = 4
    }


    public interface ITransactionState
    {
        void Enter(Transaction trn);
        void ChangeState(Transaction trn, TransactionState toState);
    }

    public class CreatedState : ITransactionState
    {
        public CreatedState(Transaction trn)
        {
            Enter(trn);
        }

        public void Enter(Transaction trn)
        {
            //check permissions
        }

        public void ChangeState(Transaction trn, TransactionState toState)
        {
            // next state can be PartialApproved or Rejected
            switch(toState)
            {
                case TransactionState.PartialApproved:
                    trn.transactionState = new PartialApprovedState(trn);
                    break;
                case TransactionState.Rejected:
                    trn.transactionState = new RejectedState(trn);
                    break;
                default:
                    // wrong transition  - log and/or throw exception
                    break;
            }
        }
    }

    public class PartialApprovedState : ITransactionState
    {
        public PartialApprovedState(Transaction trn)
        {
            Enter(trn);
        }

        public void Enter(Transaction trn)
        {
            //check permissions
        }

        public void ChangeState(Transaction trn, TransactionState toState)
        {
            // next state can be Approved or Rejected
            switch(toState)
            {
                case TransactionState.Approved:
                    trn.transactionState = new ApprovedState(trn);
                    break;
                case TransactionState.Rejected:
                    trn.transactionState = new RejectedState(trn);
                    break;
                default:
                    // wrong transition  - log and/or throw exception
                    break;
            }
        }
    }

    public class ApprovedState : ITransactionState
    {
        public ApprovedState(Transaction trn)
        {
            Enter(trn);
        }

        public void Enter(Transaction trn)
        {
            // check that approver group is other than first approver group
            // update balance
        }

        public void ChangeState(Transaction trn, TransactionState toState)
        {
            // next state can be Rejected only
            if (TransactionState.Rejected == toState)
            {
                // update balance back and 
                // go to rejected state
                trn.transactionState = new RejectedState(trn);
            }
            else
            {
                // wrong transition  - log and/or throw exception
            }
        }
    }

    public class RejectedState : ITransactionState
    {
        public RejectedState(Transaction trn)
        {
            Enter(trn);
        }

        public void Enter(Transaction trn)
        {
            // check permissions
        }

        public void ChangeState(Transaction trn, TransactionState toState)
        {
            // do nothing
            // throw exception (?)
        }
    }

}
