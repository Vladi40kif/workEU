using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace EU_Work.Pages.Models
{
    public class TaksForm 
    {
        [Key]
        public int id { get; set; }
        public DateTime dateTime { get; set; }
        public string name { get; set; }
        public string sname { get; set; }
        public string bd { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public List<WorkInfo> Works { get; set; }
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
}
