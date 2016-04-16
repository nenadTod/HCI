using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Project
{
    public abstract class Command
    {

        public abstract void Perform();
        public abstract void Rollback();

        public abstract String description
        {
            get;
        }

    }
}
