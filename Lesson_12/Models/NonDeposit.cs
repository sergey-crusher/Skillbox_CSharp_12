using Lesson_12.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_12.Models
{
    public class NonDeposit : Account, IAccount<Account>
    {
        public NonDeposit(object number, object balance) : base(number, balance)
        {
        }
    }
}
