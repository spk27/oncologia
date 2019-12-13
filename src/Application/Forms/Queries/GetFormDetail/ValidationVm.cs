using System;
using System.Linq.Expressions;
using AutoMapper;
using Oncologia.Application.Common.Mappings;
using Oncologia.Domain.Entities;

namespace Oncologia.Application.Forms.Queries.GetFormDetail {
    public class ValidationVm {
        
        public string Type { get; set; }

        public string Value { get; set; }

        public static Expression<Func<FormValidation, ValidationVm>> Projection {
            get {
                return f => new ValidationVm {
                    Type = f.Validation.Type,
                    Value = f.Validation.ValidationValue
                };
            }
        }

        public static ValidationVm Create(FormValidation validation) {
            return Projection.Compile().Invoke(validation);
        }
    }
}