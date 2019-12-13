using System.Collections.Generic;

namespace Oncologia.Application.Forms.Queries.GetFormDetail
{
    public class FormListVm
    {
        public IList<FormDetailVm> Formulario { get; set; }

        public int Count { get; set; }
    }
}
