﻿using System;

namespace SoftwareAcademy
{
    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;
        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }
        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("This value property cannot be null or empty!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.Town))
            {
                return base.ToString();
            }
            return base.ToString() + "; Town=" + this.Town;
        }
    }
}
