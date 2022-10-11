using Carte2Layer.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace carte2Layer.Infrastructure
{
    public class SqlCarteData : ICarte
    {
        private readonly CarteDbContext db;

        public SqlCarteData(CarteDbContext db)
        {
            this.db = db;
        }


        public Citoyen Add(Citoyen newCitoyen)
        {
            db.Add(newCitoyen);
            return newCitoyen;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Citoyen Delete(int CIN)
        {
            var citoyen = GetById(CIN);
            if (citoyen != null)
            {
                db.Citoyens.Remove(citoyen);
            }
            return citoyen;
        }

        public IEnumerable<Citoyen> GetAll()
        {
            return db.Citoyens;
        }

        public Citoyen GetById(int CIN)
        {
            var citoyen = db.Citoyens.FirstOrDefault(r => r.CIN == CIN);
            return citoyen;
        }

        public Citoyen Update(Citoyen UpdatedCitoyen)
        {
            var entity = db.Citoyens.Attach(UpdatedCitoyen);
            entity.State = EntityState.Modified;
            return UpdatedCitoyen;
        }

        
    }
}
