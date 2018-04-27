using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace comp2007w2018finalB.Models
{
    public class EFBreweryRepository : IMockBreweryRepository
    {
        // database connection
        private CraftBrewingModel db = new CraftBrewingModel();

        public IQueryable<Brewery> Breweries { get { return db.Breweries; } }

        public void Save(Brewery Breweries)
        {
            if (Breweries.BreweryId !=null)
            {

                db.Entry(this.Breweries).State = EntityState.Modified;


            }

            else
            {


                db.Breweries.Add(Breweries);

            }
        }
    }
}