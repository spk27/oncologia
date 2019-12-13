using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Oncologia.Application.Common.Mappings;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Forms.Queries.GetFormDetail {
    public class FormDetailVm {
        public string KeyField { get; set; }
        public string ValueField { get; set; }
        public string Label { get; set; }
        public int? Order { get; set; }
        public int? ColumnsSize { get; set; }
        public string ControlType { get; set; }

        public List<ValidationVm> Validations { get; set; }

        public static Expression<Func<FormField, FormDetailVm>> Projection {
            get {
                return f => new FormDetailVm {
                    KeyField = f.KeyField,
                    ValueField = f.ValueField,
                    Label = f.Label,
                    Order = f.Order,
                    ColumnsSize = f.ColumnsSize,
                    ControlType = f.ControlType,
                    Validations = f.FormValidation != null ? f.FormValidation.Select(fv => ValidationVm.Create(fv)).ToList() : null
                };
            }
        }

        public static FormDetailVm Create(FormField formfield) {
            return Projection.Compile().Invoke(formfield);
        }
    }
}