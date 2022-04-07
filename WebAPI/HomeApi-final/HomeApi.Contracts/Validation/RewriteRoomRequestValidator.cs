using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HomeApi.Contracts.Models.Rooms;

namespace HomeApi.Contracts.Validation
{
    public class RewriteRoomRequestValidator : AbstractValidator<RewriteRoomRequest>
    {
        public RewriteRoomRequestValidator()
        {                     
            RuleFor(x => x.NewVoltage).InclusiveBetween(120, 220);
            RuleFor(x => x.Name).NotEmpty().Must(BeSupported)
                .WithMessage($"Please choose one of the following locations: {string.Join(", ", Values.ValidRooms)}"); ;
        }

        /// <summary>
        ///  Метод кастомной валидации для свойства location
        /// </summary>
        private bool BeSupported(string location)
        {
            return Values.ValidRooms.Any(e => e == location);
        }

    }
}
