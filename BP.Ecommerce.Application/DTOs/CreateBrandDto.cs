using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Aplication.DTOs
{
    public class CreateBrandDto
    {

        public string Name { get; set; }
        public bool Status { get; set; } = true;
    }
}
