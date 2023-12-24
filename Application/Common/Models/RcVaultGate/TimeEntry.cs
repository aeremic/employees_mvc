using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models.RcVaultGate
{
    public class TimeEntry
    {
        [JsonProperty("Id", NullValueHandling = NullValueHandling.Ignore)]
        public virtual Guid? Id { get; set; }

        [JsonProperty("EmployeeName", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string? EmployeeName { get; set; }

        [JsonProperty("StarTimeUtc", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime? StarTimeUtc { get; set; }

        [JsonProperty("EndTimeUtc", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime? EndTimeUtc { get; set; }

        [JsonProperty("EntryNotes", NullValueHandling = NullValueHandling.Ignore)]
        public virtual string? EntryNotes { get; set; }

        [JsonProperty("DeletedOn", NullValueHandling = NullValueHandling.Ignore)]
        public virtual DateTime? DeletedOn { get; set; }
    }
}
