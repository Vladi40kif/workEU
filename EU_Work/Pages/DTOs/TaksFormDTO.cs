﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EU_Work.Pages.DTOs
{
    public class TaksFormDTO
    {
        public string name { get; set; }
        public string sname { get; set; }
        public object bd { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public Work[] Works { get; set; }
        public bool officilal_ukr_work_any_time { get; set; }
        public bool officilal_eu_work_any_time { get; set; }
        public bool officilal_ukr_work_now { get; set; }
        public bool officilal_eu_work_now { get; set; }
        public bool presonal_data_agree { get; set; }

        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();
            foreach (PropertyInfo propertyInfo in propertyInfoList)
            {
                if (propertyInfo.Name == "Works")
                {
                    foreach (var ed in Works)
                        result.AppendFormat("{0}: \n{1}\n\n", propertyInfo.Name, ed.ToString());
                    continue;
                }
                result.AppendFormat("{0}: {1}\n\n", propertyInfo.Name, propertyInfo.GetValue(this));
            }
            return result.ToString();
        }
    }

    public partial class Work
    {
        public string Country { get; set; }
        public string AvrSalery { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public bool OffenThinks { get; set; }
        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();
            foreach (PropertyInfo propertyInfo in propertyInfoList)
                result.AppendFormat("\t{0}: {1}\n", propertyInfo.Name, propertyInfo.GetValue(this));

            return result.ToString();
        }
    }

    
}
