﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiftciEvi.Models.viewModel
{
    public class loginModel
    {
        [Required(ErrorMessage = "Cep Telefonu Giriniz.")]
        [Phone]
        public string Cep { get; set; }


        [Required(ErrorMessage = "Şifreyi Giriniz.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}
