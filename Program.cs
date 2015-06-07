using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Transaction testTransaction = new Transaction();

            Console.WriteLine(testTransaction.ToString());
            // first approve or reject
            testTransaction.ChangeStateToPartialApproved();
            Console.WriteLine(testTransaction.ToString());

            // second approve or reject
            testTransaction.ChangeStateToApproved();
            Console.WriteLine(testTransaction.ToString());

            // wrong try to move to partial approved
            testTransaction.ChangeStateToPartialApproved();
            Console.WriteLine(testTransaction.ToString());

        }
    }
}
