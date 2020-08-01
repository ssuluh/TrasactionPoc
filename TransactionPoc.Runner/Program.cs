using System;
using TransactionPoc.Core;

namespace TransactionPoc.Runner
{
    class Program
    {
        static void Main(string[] args)
     {
            using (var db = new DataContext())
            {
                using (var tr = db.Database.BeginTransaction())
                {
                    db.Persons.Add(new Core.Model.Person { FirstName = "Mary", LastName = "Jane" });
                    db.SaveChanges();
                    using (var db2 = new DataContext())
                    {
                        using (var tr2 = db2.Database.BeginTransaction())
                        {

                            db2.Pets.Add(new Core.Model.Pet { Name = "Gasta" });
                            db2.SaveChanges();


                            tr2.Rollback();
                        }
                    }

                    db.Persons.Add(new Core.Model.Person { FirstName = "John", LastName = "Rambo" });
                    db.SaveChanges();

                    tr.Commit();
                }
            }
        }
    }
}
