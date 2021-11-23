using System;
using System.Collections.Generic;

#nullable disable

namespace ContractManager1.Models
{
    public partial class ContractDetail
    {
        public string ContractId { get; set; }
        public string WorkerName { get; set; }
        public string WorkerNumber { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentAddress { get; set; }
        public string Domain { get; set; }
        public string Project { get; set; }
        public string WorkLocation { get; set; }
        public DateTime StartDatee { get; set; }
        public DateTime EndDate { get; set; }
        public string DescriptionDetails { get; set; }
        public string Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? RecordStatus { get; set; }
        public string Email { get; set; }
        public string FilePath { get; set; }
    }
}
