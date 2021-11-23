 using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


#nullable disable

namespace ContractManager1MVC.Models
{
    public partial class ContractDetail
    {
        [Required(ErrorMessage = "ContractID is required")]
        [StringLength(15,MinimumLength =6)]
        public string ContractId { get; set; }


        [Required(ErrorMessage = "ContractID is required")]
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Invalid character")]
        public string WorkerName { get; set; }



        [Required]             
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter valid number")]
        public string WorkerNumber { get; set; }



        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }


        [Required(ErrorMessage = "DOB is required")]
        public DateTime DateOfBirth { get; set; }


        [Required(ErrorMessage = "CurrentAddress is required")]
        [StringLength(100,MinimumLength =5)]
        public string CurrentAddress { get; set; }



        [Required(ErrorMessage = "Domain is required")]
        public string Domain { get; set; }



        [Required(ErrorMessage = "Project is required")]
        public string Project { get; set; }



        [Required(ErrorMessage = "Worklocation is required")]
        public string WorkLocation { get; set; }


        [Required(ErrorMessage = "Start date is required")]
        [DataType(DataType.Date)]
        public DateTime StartDatee { get; set; }

        [Required(ErrorMessage = "End date is required")]
        [DataType(DataType.Date)]
        
        public DateTime EndDate { get; set; }



        public string DescriptionDetails { get; set; }



        [Required(ErrorMessage = "Amount is required")]
        public string Amount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? RecordStatus { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string FilePath { get; set; }
    }
}
