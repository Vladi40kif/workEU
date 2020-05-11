using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EU_Work.Pages.Models
{
    public class WorkInfo
    {
        [Key]
        public int id { get; set; }
        public string Country { get; set; }
        public string AvrSalery { get; set; }
        public string Start { get; set; }
        public string Stop { get; set; }
        public bool OffenThinks { get; set; }
        public TaksForm taksForm { get; set; }
        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();
            foreach (PropertyInfo propertyInfo in propertyInfoList) {
                if (propertyInfo.Name == "taksForm")
                    continue;
                result.AppendFormat("\t{0}: {1}\n", propertyInfo.Name, propertyInfo.GetValue(this));
            }
            return result.ToString();
        }
    }
}
