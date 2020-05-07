using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EU_Work.Pages.DTOs
{
    public class WorkFormDTO
    {
        /*

           {
              "name":"Valera",
              "sname":"Didivich",
              "bd":null,
              "educations":
                [{"Institution":"","Faculty":"","Form":"","Start":"","Stop":""}],
              "addres_official":"fsdfsdfsdf"
              ,"phone":"+380950019640",
              "email":"nfk.if@i.ua",
              "officilal_ukr_work_any_time":true,
              "officilal_eu_work_any_time":true,
              "officilal_ukr_work_now":true,
              "officilal_eu_work_now":false,"about":"",
              "presonal_data_agree":true
           }"

              */
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sname")]
        public string Sname { get; set; }

        [JsonProperty("bd")]
        public object Bd { get; set; }

        [JsonProperty("educations")]
        public Education[] Educations { get; set; }

        [JsonProperty("addres_official")]
        public string AddresOfficial { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("officilal_ukr_work_any_time")]
        public bool OfficilalUkrWorkAnyTime { get; set; }

        [JsonProperty("officilal_eu_work_any_time")]
        public bool OfficilalEuWorkAnyTime { get; set; }

        [JsonProperty("officilal_ukr_work_now")]
        public bool OfficilalUkrWorkNow { get; set; }

        [JsonProperty("officilal_eu_work_now")]
        public bool OfficilalEuWorkNow { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("presonal_data_agree")]
        public bool PresonalDataAgree { get; set; }

        public override string ToString()
        {
            Type objType = this.GetType();
            PropertyInfo[] propertyInfoList = objType.GetProperties();
            StringBuilder result = new StringBuilder();
            foreach (PropertyInfo propertyInfo in propertyInfoList) {
                if (propertyInfo.Name == "Educations") {
                    foreach (var ed in Educations)
                        result.AppendFormat("{0}: \n{1}\n\n", propertyInfo.Name, ed.ToString());
                    continue;
                }
                result.AppendFormat("{0}: {1}\n\n", propertyInfo.Name, propertyInfo.GetValue(this));
            }
            return result.ToString();
        }

    }
    public partial class Education
    {
        [JsonProperty("Institution")]
        public string Institution { get; set; }

        [JsonProperty("Faculty")]
        public string Faculty { get; set; }

        [JsonProperty("Form")]
        public string Form { get; set; }

        [JsonProperty("Start")]
        public string Start { get; set; }

        [JsonProperty("Stop")]
        public string Stop { get; set; }

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
