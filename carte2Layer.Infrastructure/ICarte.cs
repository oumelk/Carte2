using Carte2Layer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace carte2Layer.Infrastructure
{
    public interface ICarte
    {
       
        Citoyen Add(Citoyen newCitoyen);
        Citoyen GetById(int CIN);

        Citoyen Update(Citoyen UpdatedCitoyen);

        Citoyen Delete(int CIN);
        int Commit();
        IEnumerable<Citoyen> GetAll();
    }
}
