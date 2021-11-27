using DIO.Series.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DIO.Series.Classes
{
    public class SerieRepository : IRepository<Serie>
    {
        private List<Serie> ListSeries = new List<Serie>();

        public void Delete(int id)
        {
            ListSeries[id].Delete();
        }

        public void Insert(Serie entity)
        {
            ListSeries.Add(entity);
        }

        public List<Serie> Liist()
        {
            return ListSeries;
        }

        public int NextId()
        {
            return ListSeries.Count;
        }

        public Serie ReturnById(int id)
        {
            return ListSeries[id];
        }

        public void Update(int id, Serie entity)
        {
            ListSeries[id] = entity;
        }
    }
}
