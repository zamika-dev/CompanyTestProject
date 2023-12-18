using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyTestProject.Application.Features.UserProduct.Command.Delete
{
    public class DeleteUserProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
