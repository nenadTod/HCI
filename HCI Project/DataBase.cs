using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Project
{
    class DataBase
    {

        private static DataBase instance;
        private databaseEntities dataEntities;
        private DbContextTransaction tx;

        public DataBase() 
        {
            dataEntities = new databaseEntities();
            tx = dataEntities.Database.BeginTransaction();

        }

        public static DataBase Instance()
        {
            if (instance == null)
                 {
                    instance = new DataBase();
                 }
              
            return instance;
        }

        public databaseEntities DataEnteties{
            get { return dataEntities; }
        }

        public void Save()
        {
            tx.Commit();
            dataEntities = new databaseEntities();
            tx = dataEntities.Database.BeginTransaction();
        }
    }
}
