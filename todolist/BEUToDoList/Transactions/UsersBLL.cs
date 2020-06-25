using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUToDoList.Transactions
{
    public class UsersBLL
    {
        public static void Create(tblUser u)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tblUser.Add(u);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static tblUser Get(int? id)
        {
            Entities db = new Entities();
            return db.tblUser.Find(id);
        }

        public static void Update(tblUser tblUser)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tblUser.Attach(tblUser);
                        db.Entry(tblUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static tblUser GetUser(string email, string password)
        {
            Entities db = new Entities();
            return db.tblUser.FirstOrDefault(e => e.email == email && e.pass == password);
        }

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tblUser tblUser = db.tblUser.Find(id);
                        db.Entry(tblUser).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static List<tblUser> List()
        {
            Entities db = new Entities();
    
            return db.tblUser.ToList();            
        }

    }
}

