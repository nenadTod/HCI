using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCI_Project.Commands
{
    class RemoveTypeCommand : Command
    {

        Type type = null;

        public RemoveTypeCommand(Type type)
        {
            this.type = type;
        }

        public override void Perform()
        {
            var dBE = DataBase.Instance().DataEnteties;

            if ((from t in dBE.Species where t.type_id == type.id select t).Count() != 0)
            {
                throw new Exception("Type can't be removed because there are species of that type.");
            }

            dBE.Type.Remove(type);
            dBE.SaveChanges();
        }

        public override void Rollback()
        {
            var dBE = DataBase.Instance().DataEnteties;
            dBE.Type.Add(type);
            dBE.SaveChanges();
        }

        public override string description
        {
            get { return "Remove type"; }
        }
    }
}
