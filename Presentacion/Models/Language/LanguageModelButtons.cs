using DataAccess.Repositories;
using Domain.Logic;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentacion.Models.Language
{
    public class LanguageModelButtons
    {

        public string? Register { get; set; }
        public string? Edit { get; set; }
        public string? Delete { get; set; }
        public string? Cancel { get; set; }
        public string? Reset { get; set; }
        public string? Save { get; set; }
        public string? Close { get; set; }
        public string? Title { get; set; }
        public string? User { get; set; }
        public string? Code { get; set; }
        public string? Names { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Action { get; set; }
        public string? Treatment { get; set; }
        public string? Type { get; set; }
        public string? Value { get; set; }
        public string? State { get; set; }
        public string? Privacy { get; set; }
        public string? ChangeLanguage { get; set; }
        public string? Activated { get; set; }
        public string? Disabled { get; set; }
        public string? English { get; set; }
        public string? Spanish { get; set; }
        public string? Select { get; set; }

        public string? List_user { get; set; } 
        public string? User_detail { get; set; }

        public string? Medicament { get; set; }
        public string? Description { get; set; }
        public string? Responsable { get; set; }
        public string? Detail_tratamiento { get; set; }

        public string? New_user {get;set; }
        public string? New_register { get; set; }

        public string? Language { get; set; }

        public string? ConfigSystem { get; set; }

        public string? Settings { get; set; }
        public string? Profile { get; set; }
        public string? Logout { get; set; }



        public LanguageModelButtons GetLanguageForView()
        {
            var parameters = new LogicParameterSystem();
            LanguageModelButtons language;

            var jsonString = "";
            if (parameters.GetParametersSystemById(1).State)
            {

                jsonString = System.IO.File.ReadAllText("./Models/Language/" + parameters.GetParametersSystemById(1).Value + "/Buttons.json");
                language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);


              
            }
            else
            {
                jsonString = System.IO.File.ReadAllText("./Models/Language/Spanish/Buttons.json");
                language = JsonSerializer.Deserialize<LanguageModelButtons>(jsonString);
            }
            return language;
        }
    }
}
