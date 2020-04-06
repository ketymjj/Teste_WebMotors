using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TesteWebMotors.Models
{
    public class VeiculosViewModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "A marca é obrigatório", AllowEmptyStrings = false)]
        public string marca { get; set; }
        [Required(ErrorMessage = "O modelo é obrigatório", AllowEmptyStrings = false)]
        public string modelo { get; set; }
        [Required(ErrorMessage = "A versão é obrigatório", AllowEmptyStrings = false)]
        public string versao { get; set; }
        [Required(ErrorMessage = "O ano é obrigatório", AllowEmptyStrings = false)]
        public int ano { get; set; }
        [Required(ErrorMessage = "A quilometragem é obrigatório", AllowEmptyStrings = false)]
        public int quilometragem { get; set; }
        [Required(ErrorMessage = "A obsercação é obrigatório", AllowEmptyStrings = false)]
        public string observacao { get; set; }

        public List<VeiculosViewModel> Veiculos { get; set; }
    }
}