using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Practica_04.Models
{
    public class Fails
    {
            public int id {get; set;}
            public string userName{ get; set;}
            public string imageTitle {get; set;}
            public string rootImageProduct { get; set; }
            [NotMapped]
            public IFormFile imageFile { get; set; }

            public DateTime Date { get { return DateTime.Now; } }
    }
}