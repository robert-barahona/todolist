using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUToDoList.Transactions
{
    public class BoardsBLL
    {
        public static void Create(tblBoard b)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tblBoard.Add(b);
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

        public static tblBoard Get(int? id)
        {
            Entities db = new Entities();
            return db.tblBoard.Find(id);
        }

        public static void Update(tblBoard tblBoard)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.tblBoard.Attach(tblBoard);
                        db.Entry(tblBoard).State = System.Data.Entity.EntityState.Modified;
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

        public static void Delete(int? id)
        {
            using (Entities db = new Entities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        tblBoard tblBoard = db.tblBoard.Find(id);
                        db.Entry(tblBoard).State = System.Data.Entity.EntityState.Deleted;
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

        public static List<tblBoard> List()
        {
            Entities db = new Entities();

            return db.tblBoard.ToList();
        }
    }
}
