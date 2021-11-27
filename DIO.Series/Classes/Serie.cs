using DIO.Series.Enum;
using System;

namespace DIO.Series
{
    public class Serie : BaseEntity
    {
        private Gender Gender { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Deleted { get; set; }

        public Serie(int id, Gender gender, string title, string description, int year)
        {
            Id = id;
            Gender = gender;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public override string ToString()
        {
            string returns = "";

            returns += "Gender: " + Gender + Environment.NewLine;
            returns += "Title: " + Title + Environment.NewLine;
            returns += "Description: " + Description + Environment.NewLine;
            returns += "Start year: " + Year + Environment.NewLine;
            returns += "Deleted: " + Deleted;

            return returns;
        }

        public bool IsDeleted()
        {
            return Deleted;
        }

        public string ReturnTitle()
        {
            return Title;
        }

        public int ReturnId()
        {
            return Id;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
